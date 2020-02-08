using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private Projectile projectile;
    private int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<HealthSystem>() != null && other.gameObject != projectile.owner.gameObject)
        {
            other.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }
}
