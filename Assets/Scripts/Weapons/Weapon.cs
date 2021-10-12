using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FIRE_MODE{
        SEMI_AUTO = 0,
        BURST_FIRE = 1,
        FULL_AUTO = 2

};

public class Weapon : MonoBehaviour
{
    #region VARIABLE_DECLARATION
        #region WEAPON_STATS
        [SerializeField] private string weaponName;
        [SerializeField] private float damagePerSecond;

        // Speed of Projectiles
        [SerializeField] private float rateOfFire;
        [SerializeField] private float bulletVelocity;
        // Reloading and Ammo
        [SerializeField] private float reloadTime;
        public float ReloadTime{
            get{
                return reloadTime;
            }
        }
        [SerializeField] private int ammoLeftInMagazine;

        public int AmmoLeftInMagazine{
            get{
                return ammoLeftInMagazine;
            }
        }
        [SerializeField] private int magazineSize;
        [SerializeField] private int maxAmmo;
        [SerializeField] private int currentAmmo;
        [SerializeField] private bool hasUnlimitedAmmo;

        // Distance and Accuracy
        [SerializeField, Range(0, 50)][Tooltip("Higher is more inaccurate")] private float accuracy; // Lower number = more accurate
        [SerializeField] private float range;
        // Weapon 
        [SerializeField] private FIRE_MODE fireMode;

        public FIRE_MODE FireMode {
            get{
                return fireMode;
            }
        }

        #endregion WEAPON_STATS
        #region MISC_VARIABLES
        // Misc
        [SerializeField] private GameObject projectileType;
        [SerializeField] private Transform startPosition;
        [SerializeField] private List<GameObject> InactiveProjectiles;

        #endregion MISC_VARIABLES
    #endregion VARIABLE_DECLARATION
    public void FireWeapon(){
        if(InactiveProjectiles.Count == 0)
            CreateProjectile(startPosition, projectileType);
        else
            ResetProjectile();
    }
    public void ReloadWeapon(){
        if(currentAmmo >= magazineSize)
            ammoLeftInMagazine = magazineSize;
        else if(currentAmmo < magazineSize)
            ammoLeftInMagazine = currentAmmo;
        if(hasUnlimitedAmmo){
            ammoLeftInMagazine = magazineSize;
            currentAmmo = maxAmmo;
        }
    }

    public float calculateRefireDelay(){
        return 60 / rateOfFire;
    }
    private void CreateProjectile(Transform _startPosition, GameObject _projectileType){
        GameObject _projectileObject = Instantiate(_projectileType, _startPosition.position, _startPosition.rotation * Quaternion.Euler(new Vector3(0, Random.Range(-(Random.value * accuracy), Random.value * accuracy), 0)));
        Projectile _projectile = _projectileObject.AddComponent<Projectile>() as Projectile;
        _projectile.AssignValues(bulletVelocity, range, gameObject);
        GAME_MANAGER.AddProjectileToContainer(_projectileObject);
        ammoLeftInMagazine--;
        currentAmmo--;
    }

    private void ResetProjectile(){
        GameObject _projectile = InactiveProjectiles[0];
        Quaternion accuracyOffset = Quaternion.Euler(new Vector3(0, Random.Range(-(Random.value * accuracy), Random.value * accuracy), 0));
        _projectile.GetComponent<Projectile>().Initialize(gameObject, startPosition, accuracyOffset);
        _projectile.SetActive(true);
        RemoveFromInactiveProjectileList(_projectile);
        ammoLeftInMagazine--;
        currentAmmo--;
    }

    public void AddToInactiveProjectileList(GameObject _projectile){
        InactiveProjectiles.Add(_projectile);
    }
    public void RemoveFromInactiveProjectileList(GameObject _projectile){
        InactiveProjectiles.Remove(_projectile);
    }
}
