using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerCharacter))]
public class CharacterDamageReceiver : MonoBehaviour, IDamageReceiver
{
    private PlayerCharacter playerCharacter;
    private StunComponent stunComponent;
    private CharacterHealthComponent characterHealthComponent;
    private Knockable knockableComponent;
    private PushComponent pushComponent;

    public Action onPlayerTakeDamage;
    public event Action<int> onTakeDamage;
    public UnityEvent onTakeDamageWhenInvincible;

    public List<Func<bool>> invincibleConditions;
    

    public bool isInvincible => invincibleConditions.Any(condition => condition());
    private void Awake()
    {
        
        playerCharacter = GetComponent<PlayerCharacter>();
        stunComponent = GetComponent<StunComponent>();
        characterHealthComponent = GetComponent<CharacterHealthComponent>();
        knockableComponent = GetComponent<Knockable>();
        pushComponent = GetComponent<PushComponent>();
        invincibleConditions = new List<Func<bool>>();
        invincibleConditions.Add(DashInvincibleCondition);
    }

    private bool DashInvincibleCondition()
    {
        if (playerCharacter.dashInvincibleTimeCounter > 0)
        {
            playerCharacter.onPlayerDodgeSucceed?.Invoke();
            return true;
        }

        return false;

    }

    public void Analyze(DamageData damageData, Transform damageOwner)
    {
        if (isInvincible)
        {
            onTakeDamageWhenInvincible?.Invoke();
            return;
        }
        
        
        foreach (var aep in GetComponentsInChildren<IAttackEffectProcessor>())
        {
            aep.Process(damageData);
        }

        if (!string.IsNullOrEmpty(damageData.hitSound) && damageData.hitSound.GetAudioType() != AudioType.None)
        {
            InfiniteSoundPlayer.instance.PlayAudio(damageData.hitSound.GetAudioType());
        }
        else
        {
            InfiniteSoundPlayer.instance.PlayAudio(AudioType.HitSoundGeneral);
        }
        
        
        // Dealing with push
        if (damageData.pushPower > 0)
        {
            if (damageData.pushType == PushType.SpecificAngleOnly)
            {
                pushComponent.Push(damageOwner, damageData.pushPower, damageData.offSetDegree, damageData.pushDistance);
            }
            else if (damageData.pushType == PushType.AccordingToRelativePosition)
            {
                pushComponent.Push(damageOwner, damageData.pushPower, damageData.pushDistance);
            }
        }

        // Dealing with hit stun
        if (damageData.hitStunPower > 0)
        {
            stunComponent.SetStunTime(damageData.hitStunPower);
        }

        // Dealing with health reduction
        if (damageData.damage > 0)
        {
            characterHealthComponent.TakeDamage(damageData , damageOwner,true);
        }

        if (damageData.launcherHorizontalForce > 0 || damageData.launcherVerticalForce > 0)
        {
            knockableComponent.KnockUp(damageData.launcherHorizontalForce, damageData.launcherVerticalForce, damageOwner);
        }


        if (damageOwner.GetComponent<ComboGauge>() != null)
        {
            damageOwner.GetComponent<ComboGauge>().AddComboNum();
            lastDamageOwner = damageOwner.GetComponent<PlayerCharacter>();
        }

        if (damageOwner.GetComponent<Projectile>() != null)
        {
            lastDamageOwner = damageOwner.GetComponent<Projectile>().owner;
            damageOwner.GetComponent<Projectile>()?.owner.GetComponent<ComboGauge>()?.AddComboNum();
        }

        if (damageOwner.GetComponent<NewProjectileDamageComponent>() != null)
        {
            lastDamageOwner = damageOwner.GetComponent<NewProjectileDamageComponent>()?.owner.GetComponent<PlayerCharacter>();
            damageOwner.GetComponent<NewProjectileDamageComponent>()?.owner.GetComponent<ComboGauge>()?.AddComboNum();
        }
        onPlayerTakeDamage?.Invoke();
        onTakeDamage?.Invoke(damageData.damage);
    }

    private PlayerCharacter lastDamageOwner;

    public void Analyze(DamageData damageData)
    {
        Analyze(damageData,lastDamageOwner.transform);    // TODO  Fix bug
    }
    
    
}