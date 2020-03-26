using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamageReceiver : MonoBehaviour, IDamageReceiver
{
    private GhostStats ghostStats;

    private void Awake()
    {
        ghostStats = GetComponent<GhostStats>();
    }

    public void Analyze(DamageData damageData, Transform damageOwner)
    {
        ghostStats.health -= damageData.damage;
        if (ghostStats.health <= 0)
        {
            GetComponent<GhostEventSystem>().GhostDie();
        }
    }
}
