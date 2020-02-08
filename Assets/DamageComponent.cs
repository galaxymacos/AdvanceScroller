using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private Projectile projectile;
    private int damage = 20;
    // Start is called before the first frame update

    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectile.onProjectileHitTarget += DealDamage;
    }

    public void DealDamage(GameObject target)
    {
        if (target.GetComponent<HealthComponent>() != null)
        {
            target.GetComponent<HealthComponent>().TakeDamage(damage);
        }
    }
}
