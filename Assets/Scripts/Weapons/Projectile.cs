using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float range;
    private float bulletVelocity;    
    private Vector3 lastPosition;
    private Weapon currentWeapon;

    private float distanceTraveled;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FireProjectile();
    }

    private void FireProjectile(){
        transform.Translate(Vector3.forward * bulletVelocity * Time.deltaTime);
        distanceTraveled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        ExpireProjectile(distanceTraveled, range);
    }

    private void ExpireProjectile(float _distanceTraveled, float _range){
        if(_distanceTraveled >= _range){
            gameObject.SetActive(false);
        }
    }

    public void AssignValues(float _bulletVelocity, float _range){
        bulletVelocity = _bulletVelocity;
        range = _range;
    }
}
