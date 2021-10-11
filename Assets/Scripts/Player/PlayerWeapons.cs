using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private List<Weapon> Weapons;

    private bool canFire = true;
    private float timeSinceLastShot = 0f;

    private float refireDelay;


    // Start is called before the first frame update
    void Start()
    {
        refireDelay = currentWeapon.calculateRefireDelay();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastShot >= refireDelay){
            canFire = true;
        }

        if(Input.GetMouseButton(0) && canFire){
            currentWeapon.FireWeapon();
            timeSinceLastShot = 0;
            canFire = false;
        }

        timeSinceLastShot++;
    }
}
