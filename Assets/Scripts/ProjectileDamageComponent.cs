using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageComponent : MonoBehaviour
{
    private Projectile projectile;
    [SerializeField] private int damage = 20;

    // [SerializeField] private int maxDamageTimeForOneTarget;

    private List<HealthComponent> targets;
    // Start is called before the first frame update

    private void Awake()
    {
        targets = new List<HealthComponent>();
        projectile = GetComponent<Projectile>();
        projectile.onProjectileCollided += DealDamage;
    }

    public void DealDamage(GameObject target)
    {
        var healthComponent = target.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            if (!targets.Contains(healthComponent))
            {
                targets.Add(healthComponent);
                target.GetComponent<HealthComponent>().TakeDamage(damage);
            }
        }
    }
}


