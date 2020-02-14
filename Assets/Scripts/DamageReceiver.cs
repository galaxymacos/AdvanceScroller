using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacter))]
public class DamageReceiver : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    private StunComponent stunComponent;
    private HealthComponent healthComponent;
    private Knockable knockableComponent;
    private PushComponent pushComponent;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
        stunComponent = GetComponent<StunComponent>();
        healthComponent = GetComponent<HealthComponent>();
        knockableComponent = GetComponent<Knockable>();
        pushComponent = GetComponent<PushComponent>();
    }

    public void Analyze(DamageData damageData, Transform damageOwner)
    {
        if (damageData.pushPower > 0)
        {
            if (Math.Abs(damageData.offSetDegree) < Mathf.Epsilon)
            {
                pushComponent.Push(damageOwner, damageData.pushPower);
            }
            else
            {
                pushComponent.Push(damageOwner, damageData.pushPower, damageData.offSetDegree);
            }
        }

        if (damageData.hitStunPower > 0)
        {
            stunComponent.SetStunTime(damageData.hitStunPower);
        }

        if (damageData.damage > 0)
        {
            healthComponent.TakeDamage(damageData.damage);
        }

        if (damageData.launcherHorizontalForce > 0 || damageData.launcherVerticalForce > 0)
        {
            knockableComponent.KnockUp(damageData.launcherHorizontalForce, damageData.launcherVerticalForce, damageOwner);
        }
    }    
}