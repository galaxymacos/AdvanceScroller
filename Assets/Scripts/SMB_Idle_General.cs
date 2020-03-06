using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Idle_General : CharacterStateMachineBehavior
{
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);

        if (!playerCharacter.isGrounded)
        {
            _animator.SetTrigger("fall down");
        }

        if (playerCharacter.isDead)
        {
            _animator.SetTrigger("die");
        }
        
    }
}
