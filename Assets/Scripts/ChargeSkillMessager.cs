using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSkillMessager : MonoBehaviour
{
    public Action<ChargeSkill> onFireChargeSkill; 
    
    private ChargeSkill currentChargeSkill;
    private PlayerCharacter playerCharacter;
    private DamageReceiver damageReceiver;
    private bool hasChargeSkillReleased;


    private void Awake()
    {
        damageReceiver = GetComponent<DamageReceiver>();
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    private void OnEnable()
    {
        onFireChargeSkill += SetCurrentChargeSkill;
        damageReceiver.onPlayerTakeDamage += InterruptCurrentChargeSkill;
        playerCharacter.onPlayerStartDash += InterruptCurrentChargeSkill;
    }

    private void OnDisable()
    {
        onFireChargeSkill -= SetCurrentChargeSkill;
        damageReceiver.onPlayerTakeDamage -= InterruptCurrentChargeSkill;
        playerCharacter.onPlayerStartDash -= InterruptCurrentChargeSkill;

    }
    

    public void ReleaseCurrentChargeSkill()
    {
        if (currentChargeSkill != null)
        {
            currentChargeSkill.ReleaseCharging();
        }
    }

    public void SetCurrentChargeSkill(ChargeSkill chargeSkill)
    {
        // If player is currently charging an ability
        // if (chargeSkill != null)
        // {
            // chargeSkill.InteruptCharging();
        // }
        
        // Set the current charge skill to new charge skill
        hasChargeSkillReleased = false;
        currentChargeSkill = chargeSkill;
    }

    public void InterruptCurrentChargeSkill()
    {
        if (currentChargeSkill != null && !currentChargeSkill.hasReleased)
        {
            currentChargeSkill.InteruptCharging();
        }
    }
}
