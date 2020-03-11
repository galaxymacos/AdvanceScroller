using System;
using UnityEngine;

public class BleedingEffectProcessor: MonoBehaviour, IAttackEffectProcessor
{
    public CharacterHealthComponent healthComponent;
    private float bleedTimeCounter;
    private float bleedPerSecond;

    private Action onStartBleeding;
    public bool isBleeding => bleedTimeCounter > 0;

    private void Awake()
    {
        healthComponent = GetComponentInParent<CharacterHealthComponent>();
        healthComponent.OnTakeHit += ProcessBridge;
        onStartBleeding += SpawnBloodParticleBridge;
    }

    private void ProcessBridge(CharacterHealthComponent health)
    {
        Process(health.damageDataFromLastAttack);
    }


    public void Process(DamageData damageData)
    {
        foreach (ScriptableObject attackEffect in damageData.attackEffects)
        {
            var bleedingEffect = attackEffect as BleedingEffect;
            if (bleedingEffect != null)
            {
                bleedTimeCounter = bleedingEffect.bleedTime;
                bleedPerSecond = bleedingEffect.bleedAmountPerSecond;
                onStartBleeding?.Invoke();
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

    private void SpawnBloodParticleBridge()
    {
        var bloodParticleSystem = GetComponentInParent<BloodParticleSpawner>();
        if (bloodParticleSystem != null)
        {
            bloodParticleSystem.SpawnBloodDrippingParticle(bleedTimeCounter);
        }
    }
}