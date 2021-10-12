using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private List<Weapon> Weapons;

    private bool canFire = true;
    private float timeSinceLastShot = 0f;
    private float timeSinceBeginReload = 0f;
    private float refireDelay;
    private float reloadDelay;


    // Start is called before the first frame update
    void Start()
    {
        refireDelay = currentWeapon.calculateRefireDelay();
        reloadDelay = currentWeapon.calculateReloadDelay();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && canFire){
            StartCoroutine(FireWeapon());
        }
    }

    IEnumerator FireWeapon(){
        if(currentWeapon.AmmoLeftInMagazine != 0){
            currentWeapon.FireWeapon();
            canFire = false;
            Debug.Log(refireDelay);
            yield return new WaitForSeconds(refireDelay);
        }
        else{
            canFire = false;
            yield return new WaitForSeconds(reloadDelay);
            ReloadWeapon();
        }
        canFire = true;
    }

    void ReloadWeapon(){
        currentWeapon.ReloadWeapon();
        canFire = true;
    }
}
