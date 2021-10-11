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
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject muzzle;
    public float Range{
        get {
            return range;
        }
    }
    private List<GameObject> projectiles;

    public void FireWeapon(){
        GameObject _projectile = Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation);
        projectiles.Add(_projectile);
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
