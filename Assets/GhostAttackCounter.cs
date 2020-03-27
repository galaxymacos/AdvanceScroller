using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttackCounter : MonoBehaviour
{
    public List<SingleAttackComponent> attackComponents;
    public GhostStats ghostStats;
    private void Awake()
    {
        ghostStats = GetComponent<GhostStats>();
        foreach (var attackComponent in attackComponents)
        {
            attackComponent.onAttackSucceed += IncreaseCounter;
        }
    }

    private void IncreaseCounter()
    {
        ghostStats.attackSucceedNum++;
        ghostStats.lastHitTime = Time.time;
    }

    
}
