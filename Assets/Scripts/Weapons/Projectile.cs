using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float range;
    private float bulletVelocity;  
    private Vector3 lastPosition;
    private float distanceTraveled;
    private Weapon weapon;

    public void Initialize(GameObject weapon, Transform startPosition, Quaternion accuracyOffset){
        distanceTraveled = 0;
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation * accuracyOffset;
        lastPosition = transform.position;
        AssignValues(bulletVelocity, range, weapon);
    }

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
            weapon.AddToInactiveProjectileList(gameObject);
        }
    }

    public void AssignValues(float _bulletVelocity, float _range, GameObject _weapon){
        bulletVelocity = _bulletVelocity;
        range = _range;
        weapon = _weapon.GetComponent<Weapon>();
    }
}