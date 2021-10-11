using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private List<Weapon> Weapons;

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
        if(Input.GetMouseButton(0)){
            if(timeSinceLastShot >= refireDelay){
                currentWeapon.FireWeapon();
                timeSinceLastShot = 0;
            }
        }
        timeSinceLastShot++;
    }
}
