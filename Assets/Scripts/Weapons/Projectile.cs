using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float projectileSpeed;
    private Vector3 startPosition;
    private Weapon currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        ExpireProjectile();
    }

    private void ExpireProjectile(){
        float distanceTraveled = Mathf.Abs(transform.position.x + transform.position.z);
        Debug.Log(distanceTraveled);
        // if(distanceTraveled >= range){
            
        // }
    }
}
