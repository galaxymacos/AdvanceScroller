using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrificationEffectProcessor : MonoBehaviour, IAttackEffectProcessor
{
    public CharacterHealthComponent healthComponent;
    public float duration;
    public float odd;
    public bool isElectrification => duration > 0;

    private void Awake()
    {
        healthComponent = GetComponentInParent<CharacterHealthComponent>();
        healthComponent.OnTakeHit += ProcessBridge;
    }

    private void ProcessBridge(CharacterHealthComponent health)
    {
        Process(health.damageDataFromLastAttack);
    }


    public void Process(DamageData damageData)
    {
        foreach (ScriptableObject attackEffect in damageData.attackEffects)
        {
            var electrificationEffect = attackEffect as ElectrificationEffect;
            if (electrificationEffect != null)
            {
                duration = electrificationEffect.duration;
                odd = electrificationEffect.ElectrificationOdd;
            }
        }
    }

    public void ApplyElectricityDamage()
    {
        
    }
}