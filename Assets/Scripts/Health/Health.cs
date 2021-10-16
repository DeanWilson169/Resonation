using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable<float>
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth >= maxHealth){
            currentHealth = maxHealth;
        }

        if(currentHealth < 0){
            Destroy(gameObject);
        }
    }

    public void Damage(float damageTaken){
        currentHealth -= damageTaken;
    }
}
