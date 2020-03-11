using System;
using UnityEngine;

public class BleedingEffectProcessor: MonoBehaviour, IAttackEffectProcessor
{
    public CharacterHealthComponent healthComponent;
    private float bleedTimeCounter;
    private float bleedPerSecond;

    public bool isBleeding => bleedTimeCounter > 0;

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
            bleedTimeCounter = damageData.bleedTime;
            bleedPerSecond = damageData.bleedAmountPerSecond;
        }

        foreach (ScriptableObject attackEffect in damageData.attackEffects)
        {
            var bleedingEffect = attackEffect as BleedingEffect;
            if (bleedingEffect != null)
            {
                bleedTimeCounter = bleedingEffect.bleedTime;
                bleedPerSecond = bleedingEffect.bleedAmountPerSecond;
            }
        }
    }
    
    public void Update()
    {
        if (isBleeding)
        {
            bleedTimeCounter-=Time.deltaTime;
            healthComponent.DrainHealth(bleedPerSecond*Time.deltaTime);
        }
    }
}