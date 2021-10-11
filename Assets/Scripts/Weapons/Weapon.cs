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
    [SerializeField] private int rateOfFire;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private int reloadTime;
    [SerializeField] private int magazineSize;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float accuracy;
    [SerializeField] private float range;
    [SerializeField] private FIRE_MODE fireMode;
    [SerializeField] private GameObject projectileType;
    [SerializeField] private Transform startPosition;

    public List<GameObject> ActiveProjectiles; 
    public List<Projectile> InactiveProjectiles; 

    public void Start(){

    }

    public void FireWeapon(){
        GameObject _projectile = CreateProjectile(startPosition, projectileType);
        ActiveProjectiles.Add(_projectile);
        GAME_MANAGER.AddProjectileToContainer(_projectile);
    }

    private GameObject CreateProjectile(Transform _startPosition, GameObject _projectileType){
        GameObject _projectileObject = new GameObject("Projectile");
        Projectile _projectile = _projectileObject.AddComponent<Projectile>() as Projectile;
        _projectile.AssignValues(bulletVelocity, range);
        _projectile.transform.position = _startPosition.position;
        _projectile.transform.rotation = _startPosition.rotation;
        GameObject _projectileTypeInstance = Instantiate(_projectileType, _projectile.transform.position, _projectile.transform.rotation);
        _projectileTypeInstance.transform.parent = _projectileObject.transform;
        return _projectileObject;
    }



    // public Weapon(float _damagePerSecond, int _rateOfFire, int _reloadTime, int _magazineSize, int _maxAmmo, float _accuracy, float _range, FIRE_MODE _fireMode){
    //     damagePerSecond = _damagePerSecond;
    //     rateOfFire = _rateOfFire;
    //     reloadTime = _reloadTime;
    //     magazineSize = _magazineSize;
    //     maxAmmo = _maxAmmo;
    //     accuracy = _accuracy;
    //     range =_range;
    //     fireMode = _fireMode;
    // }

}
