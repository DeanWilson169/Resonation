using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Weapon secondaryWeapon;

    private bool canFire = true;
    private float refireDelay;


    // Start is called before the first frame update
    void Start()
    {
        refireDelay = currentWeapon.calculateRefireDelay();
    }

    // Update is called once per frame
    void Update()
    {
        FireWeapon();
        SwitchWeapon();
    }

    void FireWeapon(){
        switch(currentWeapon.FireMode){
            case FIRE_MODE.SEMI_AUTO: {
                if(Input.GetMouseButtonDown(0) && canFire){
                    StartCoroutine(CanFireWeapon(0));
                }
            }
            break;
            case FIRE_MODE.FULL_AUTO: {
                if(Input.GetMouseButton(0) && canFire){
                    StartCoroutine(CanFireWeapon(refireDelay));
                }
            }
            break;
            case FIRE_MODE.BURST_FIRE: {
                if(Input.GetMouseButtonDown(0) && canFire){
                    StartCoroutine(BurstFireWeapon(refireDelay));
                }
            }
            break;
            default:{
                StartCoroutine(CanFireWeapon(refireDelay));
            }
            break;
        }
    }

    IEnumerator CanFireWeapon(float _refireDelay){
        if(currentWeapon.AmmoLeftInMagazine != 0){
            currentWeapon.FireWeapon();
            canFire = false;
            yield return new WaitForSeconds(_refireDelay);
        }
        else{
            canFire = false;
            yield return new WaitForSeconds(currentWeapon.ReloadTime);
            ReloadWeapon();
        }
        canFire = true;
    }

    IEnumerator BurstFireWeapon(float _refireDelay){

        for(int i = 0; i < 3; i++){
            StartCoroutine(CanFireWeapon(refireDelay));
            yield return new WaitForSeconds(0.1f);

        }
        // yield return new WaitForSeconds(0f);
    }

    void ReloadWeapon(){
        currentWeapon.ReloadWeapon();
        canFire = true;
    }

    void SwitchWeapon(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            Weapon temp = currentWeapon;
            currentWeapon = secondaryWeapon;
            secondaryWeapon = temp;
            refireDelay = currentWeapon.calculateRefireDelay();
        }
    }
}
