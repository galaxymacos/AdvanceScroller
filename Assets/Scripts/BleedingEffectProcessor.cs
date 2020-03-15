using System;
using UnityEngine;

public class BleedingEffectProcessor: MonoBehaviour, IAttackEffectProcessor
{
    public CharacterHealthComponent healthComponent;
    private float bleedTimeCounter;
    private float bleedPerSecond;

    public Action onStartBleeding;
    public Action onEndBleeding;
    public bool isBleeding => bleedTimeCounter > 0;
    private bool wasBleeding;

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
        if (damageData.attackEffects == null) return;
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

        FireEvent();
    }

    private void FireEvent()
    {
        if (isBleeding && !wasBleeding)
        {
            onStartBleeding?.Invoke();
        }
        else if (!isBleeding && wasBleeding)
        {
            onEndBleeding?.Invoke();
        }

        wasBleeding = isBleeding;
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