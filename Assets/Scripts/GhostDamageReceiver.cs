using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamageReceiver : MonoBehaviour, IDamageReceiver
{
    private GhostStats ghostStats;
    private GhostEventSystem ghostEventSystem;

    private void Awake()
    {
        ghostStats = GetComponent<GhostStats>();
        ghostEventSystem = GetComponent<GhostEventSystem>();
    }

    public void Analyze(DamageData damageData, Transform damageOwner)
    {
        ghostStats.health -= damageData.damage;
        ghostEventSystem.GhostTakeDamage(damageData);
        if (ghostStats.health <= 0)
        {
            ghostEventSystem.GhostDie();
        }
    }
}
