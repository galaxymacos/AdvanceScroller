using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKillContinuousAttack : ContinuousAttack
{
    [SerializeField] private SingleAttackComponent SingleAttackComponent;

    private void Awake()
    {
        
    }

    public override void Tick()
    {
        foreach (GameObject target in SingleAttackComponent.objectsHasProcessed)
        {
            if (target == null || target == owner.gameObject) continue;
            var damageReceiver = target.GetComponent<DamageReceiver>();
            if (damageReceiver != null)
            {
                damageReceiver.Analyze(damageData, transform.root);
            }
            
        }
    }
}
