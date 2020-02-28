using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKillContinuousAttack : ContinuousAttack
{
    [SerializeField] private SingleAttackComponent SingleAttackComponent;
    
    
    public override void OneLastStrike()
    {
        oneLastStrikeFinished?.Invoke();
        if (finalDamageData == null) return;

        foreach (GameObject target in SingleAttackComponent.objectsHasProcessed)
        {
            if (target == null || target == owner.gameObject) continue;
            var damageReceiver = target.GetComponent<DamageReceiver>();
            if (damageReceiver != null)
            {
                damageReceiver.GetComponent<CharacterPauser>().UnPause();
                print("one last strike");
                damageReceiver.Analyze(finalDamageData, transform.root);
            }
            
        }
    }

    public override void Tick()
    {
        foreach (GameObject target in SingleAttackComponent.objectsHasProcessed)
        {
            if (target == null || target == owner.gameObject) continue;
            var damageReceiver = target.GetComponent<DamageReceiver>();
            if (damageReceiver != null)
            {
                print("Instant kill tick");
                damageReceiver.Analyze(damageData, transform.root);
            }
            
        }
    }
    
}
