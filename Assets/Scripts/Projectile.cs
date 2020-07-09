using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damageAmount = 50;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();
        //reduce health
        if (attacker && health)
        {
            health.DealDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
