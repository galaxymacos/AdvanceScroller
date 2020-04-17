using System;
using UnityEngine;

public class ChargedSMB : CharacterStateMachineBehavior
{
    public GameObject chargeSkillPrefab;
    private ChargeSkill chargeSkill;
    public ChargedButton buttonToDetect;
    private bool isButtonPressed = true;
    private bool hasReleaseCharging;
    private float prevGravity;
    public bool ignoreGravity;
    
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo, layerIndex);
        GameObject chargedDagger = Instantiate(chargeSkillPrefab,playerCharacter.transform.position, Quaternion.identity);
        chargeSkill = chargedDagger.GetComponent<ChargeSkill>();
        chargeSkill.Setup(playerCharacter);
        PressDetectedButton();
        chargeSkill.StartCharging();
        hasReleaseCharging = false;

        if (ignoreGravity)
        {
            prevGravity = playerCharacter.GetComponent<Rigidbody2D>().gravityScale;
            playerCharacter.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        var chargeSkillMessager = playerCharacter.GetComponent<ChargeSkillMessager>();
        if (chargeSkillMessager != null)
        {
            chargeSkillMessager.onFireChargeSkill?.Invoke(chargeSkill);
        }
    }

    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        isButtonPressed = GetDetectedButtonState();
        if (!isButtonPressed && !hasReleaseCharging)
        {
            hasReleaseCharging = true;
            _animator.SetTrigger("charge finish");
        }
        playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }

    public override void OnStateExit(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(_animator, stateInfo, layerIndex);
        if (!hasReleaseCharging)
        {
            
            chargeSkill.InteruptCharging();
        }

        ResetChargedButton();


        if (ignoreGravity)
        {
            playerCharacter.GetComponent<Rigidbody2D>().gravityScale = prevGravity;
        }
    }

    private void PressDetectedButton()
    {
        switch (buttonToDetect)
        {
            case ChargedButton.skill1:
                playerInput.skill1ButtonPressed = true;
                break;
            case ChargedButton.skill2:
                playerInput.skill2ButtonPressed = true;
                break;
            case ChargedButton.skill3:
                playerInput.skill3ButtonPressed = true;
                break;
            case ChargedButton.skill4:
                playerInput.skill4ButtonPressed = true;
                break;
            case ChargedButton.attack:
                playerInput.attackButtonPressed = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private bool GetDetectedButtonState()
    {
        switch (buttonToDetect)
        {
            
            case ChargedButton.skill1:
                return playerInput.skill1ButtonPressed;
            case ChargedButton.skill2:
                return playerInput.skill2ButtonPressed;
            case ChargedButton.skill3:
                return playerInput.skill3ButtonPressed;
            case ChargedButton.skill4:
                return playerInput.skill4ButtonPressed;
            case ChargedButton.attack:
                return playerInput.attackButtonPressed;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private void ResetChargedButton()
    {
        switch (buttonToDetect)
        {
            case ChargedButton.skill1:
                playerInput.skill1ButtonPressed = false;
                break;
            case ChargedButton.skill2:
                playerInput.skill2ButtonPressed = false;
                break;
            case ChargedButton.skill3:
                playerInput.skill3ButtonPressed = false;
                break;
            case ChargedButton.skill4:
                playerInput.skill4ButtonPressed = false;
                break;
            case ChargedButton.attack:
                playerInput.attackButtonPressed = false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}