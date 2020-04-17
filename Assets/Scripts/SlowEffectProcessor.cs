using System;
using UnityEngine;

public class SlowEffectProcessor : MonoBehaviour, IAttackEffectProcessor
{
    private PlayerCharacter player;
    public bool SlowEffectActive => slowDuration > 0;
    private float slowPercentage;
    private float slowDuration;

    public event EventHandler<BuffEventArgs> onSlow; 
    private void Awake()
    {
        player = GetComponentInParent<PlayerCharacter>();
    }

    
    public void Process(DamageData damageData)
    {
        if (damageData.attackEffects == null) return;
        foreach (ScriptableObject attackEffect in damageData.attackEffects)
        {
            var slowEffect = attackEffect as SlowEffect;
            if (slowEffect != null)
            {
                slowPercentage = slowEffect.slowPercent;
                slowDuration = slowEffect.slowDuration;
                onSlow?.Invoke(this, new BuffEventArgs(slowEffect.slowDuration));
            }
        }

    }

    private void Update()
    {
        if (slowDuration > 0)
        {
            slowDuration -= Time.deltaTime;
            if (slowDuration <= 0)
            {
                RecoverPlayerSpeed();
            }
        }

        if (SlowEffectActive)
        {
            SlowPlayer();
        }
    }

    private void SlowPlayer()
    {
        player.limitersForMS.Add(SlowEffectConditioner);
    }

    private void RecoverPlayerSpeed()
    {
        player.limitersForMS.Remove(SlowEffectConditioner);
    }

    private float SlowEffectConditioner(float movementSpeed)
    {
        return movementSpeed * slowPercentage;
    }
}