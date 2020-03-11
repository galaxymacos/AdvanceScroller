using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrificationEffectProcessor : MonoBehaviour, IAttackEffectProcessor
{
    public CharacterHealthComponent healthComponent;

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
        if (damageData.canBleed)
        {
        }
    }
}
