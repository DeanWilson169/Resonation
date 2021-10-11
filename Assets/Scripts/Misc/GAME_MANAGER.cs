using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_MANAGER : MonoBehaviour
{
    public static GameObject ProjectileContainer;

    // Start is called before the first frame update
    public static void AddProjectileToContainer(GameObject _projectile){
        _projectile.transform.parent = ProjectileContainer.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        ProjectileContainer = new GameObject("Projectile Container");
        ProjectileContainer.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
