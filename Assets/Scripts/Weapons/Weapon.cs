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
        [SerializeField] private float damagePerSecond;

        // Speed of Projectiles
        [SerializeField] private float rateOfFire;
        [SerializeField] private float bulletVelocity;
        // Reloading and Ammo
        [SerializeField] private float reloadTime;
        [SerializeField] private int ammoLeftInMagazine;

        public int AmmoLeftInMagazine{
            get{
                return ammoLeftInMagazine;
            }
        }
        [SerializeField] private int magazineSize;
        [SerializeField] private int maxAmmo;
        // Distance and Accuracy
        [SerializeField] private float accuracy;
        [SerializeField] private float range;
        // Weapon 
        [SerializeField] private FIRE_MODE fireMode;

        #endregion WEAPON_STATS
        #region MISC_VARIABLES
        // Misc
        [SerializeField] private GameObject projectileType;
        [SerializeField] private Transform startPosition;
        [SerializeField] private List<GameObject> InactiveProjectiles;

        #endregion MISC_VARIABLES
    #endregion VARIABLE_DECLARATION
    
    public void Start(){
        
    }

    public void FireWeapon(){
        if(InactiveProjectiles.Count == 0){ 
            CreateProjectile(startPosition, projectileType);
        }
        else{
            ResetProjectile();
        }
    }
    public void ReloadWeapon(){
        ammoLeftInMagazine = magazineSize;
    }

    public float calculateReloadDelay(){
        return reloadTime; // 6000 / 
    }
    public float calculateRefireDelay(){
        return 60 / rateOfFire;
    }
    private void CreateProjectile(Transform _startPosition, GameObject _projectileType){
        GameObject _projectileObject = Instantiate(_projectileType, _startPosition.position, _startPosition.rotation);
        Projectile _projectile = _projectileObject.AddComponent<Projectile>() as Projectile;
        _projectile.AssignValues(bulletVelocity, range, gameObject);
        GAME_MANAGER.AddProjectileToContainer(_projectileObject);
        ammoLeftInMagazine--;
    }

    private void ResetProjectile(){
        GameObject _projectile = InactiveProjectiles[0];
        _projectile.GetComponent<Projectile>().Initialize(gameObject, startPosition);
        _projectile.SetActive(true);
        RemoveFromInactiveProjectileList(_projectile);
        ammoLeftInMagazine--;
    }
    public void AddToInactiveProjectileList(GameObject _projectile){
        InactiveProjectiles.Add(_projectile);
    }
    public void RemoveFromInactiveProjectileList(GameObject _projectile){
        InactiveProjectiles.Remove(_projectile);
    }
}
