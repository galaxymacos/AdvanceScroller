using System;
using UnityEngine;

public class BleedingEffectProcessor: MonoBehaviour, IAttackEffectProcessor
{
    private CharacterHealthComponent healthComponent;
    private float bleedTimeCounter;
    private float bleedPerSecond;

    public event Action onStartBleeding;
    public event Action onEndBleeding;

    public event EventHandler<BuffEventArgs> onStartBleedingEvent;
    public bool isBleeding => bleedTimeCounter > 0;
    private bool wasBleeding;

    private void Awake()
    {
        healthComponent = GetComponentInParent<CharacterHealthComponent>();
        // healthComponent.onTakeHit += ProcessBridge;
        onStartBleeding += SpawnBloodParticleBridge;
        
    }

    private void OnDestroy()
    {
        onStartBleeding -= SpawnBloodParticleBridge;
    }


    public void Process(DamageData damageData)
    {
        if (damageData.attackEffects == null) return;
        foreach (ScriptableObject attackEffect in damageData.attackEffects)
        {
            var bleedingEffect = attackEffect as BleedingEffect;
            if (bleedingEffect != null)
            {
                bleedTimeCounter = bleedingEffect.bleedDuration;
                bleedPerSecond = bleedingEffect.damagePerSecond;
                onStartBleedingEvent?.Invoke(this,new BuffEventArgs(bleedingEffect.bleedDuration));
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

        UpdateEvent();
    }

    private void UpdateEvent()
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

public class BleedEffectEventArgs: EventArgs
{
    public BleedEffectEventArgs(float bleedAmountPerSec, float bleedDuration)
    {
        this.bleedAmountPerSec = bleedAmountPerSec;
        this.bleedDuration = bleedDuration;
    }
    public float bleedAmountPerSec;
    public float bleedDuration;
}