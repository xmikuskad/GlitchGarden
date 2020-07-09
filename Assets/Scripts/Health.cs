using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float animationDuration = 0.8f;

    public void DealDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            if (deathVFX)
            {
                GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
                Destroy(deathVFXObject, animationDuration);
            }
            Destroy(gameObject);

        }
    }

}
