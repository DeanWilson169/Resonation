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
    [SerializeField] private float damagePerSecond;
    [SerializeField] private float rateOfFire;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private int reloadTime;
    [SerializeField] private int magazineSize;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float accuracy;
    [SerializeField] private float range;
    [SerializeField] private FIRE_MODE fireMode;
    [SerializeField] private GameObject projectileType;
    [SerializeField] private Transform startPosition;
    [SerializeField] private List<GameObject> InactiveProjectiles;
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

    public float calculateRefireDelay(){
        return 60000 / rateOfFire;
    }
    private void CreateProjectile(Transform _startPosition, GameObject _projectileType){
        GameObject _projectileObject = Instantiate(_projectileType, _startPosition.position, _startPosition.rotation);
        Projectile _projectile = _projectileObject.AddComponent<Projectile>() as Projectile;
        _projectile.AssignValues(bulletVelocity, range, gameObject);
        GAME_MANAGER.AddProjectileToContainer(_projectileObject);
    }

    private void ResetProjectile(){
        GameObject _projectile = InactiveProjectiles[0];
        _projectile.GetComponent<Projectile>().Initialize(gameObject, startPosition);
        _projectile.SetActive(true);
        RemoveFromInactiveProjectileList(_projectile);
    }
    public void AddToInactiveProjectileList(GameObject _projectile){
        InactiveProjectiles.Add(_projectile);
    }
    public void RemoveFromInactiveProjectileList(GameObject _projectile){
        InactiveProjectiles.Remove(_projectile);
    }
}
