using UnityEngine;

public class SlowEffectProcessor : MonoBehaviour, IAttackEffectProcessor
{
    private PlayerCharacter player;
    public bool SlowEffectActive => slowDuration > 0;
    private float slowPercentage;
    private float slowDuration;
    
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
        player.IsMoveSpeedOverriden = true;
        player.OverridenMovementSpeed = player.MovementSpeedOriginal * slowPercentage;
    }

    private void RecoverPlayerSpeed()
    {
        player.IsMoveSpeedOverriden = false;
        player.OverridenMovementSpeed = player.MovementSpeedOriginal;

    }
}