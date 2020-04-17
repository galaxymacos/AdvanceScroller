using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSkillMessager : MonoBehaviour
{
    public Action<ChargeSkill> onFireChargeSkill; 
    
    private ChargeSkill currentChargeSkill;
    private PlayerCharacter playerCharacter;
    private CharacterDamageReceiver characterDamageReceiver;
    private bool hasChargeSkillReleased;


    private void Awake()
    {
        characterDamageReceiver = GetComponent<CharacterDamageReceiver>();
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    private void OnEnable()
    {
        onFireChargeSkill += SetCurrentChargeSkill;
        characterDamageReceiver.onPlayerTakeDamage += InterruptCurrentChargeSkill;
        playerCharacter.onPlayerStartDash += InterruptCurrentChargeSkill;
    }

    private void OnDisable()
    {
        onFireChargeSkill -= SetCurrentChargeSkill;
        characterDamageReceiver.onPlayerTakeDamage -= InterruptCurrentChargeSkill;
        playerCharacter.onPlayerStartDash -= InterruptCurrentChargeSkill;

    }
    

    public void ReleaseCurrentChargeSkill()
    {
        if (currentChargeSkill != null && !currentChargeSkill.hasReleased)
        {
            currentChargeSkill.ReleaseCharging();
            currentChargeSkill.hasReleased = true;
            currentChargeSkill = null;
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
            currentChargeSkill.hasReleased = true;
            currentChargeSkill = null;

        }
    }
}
