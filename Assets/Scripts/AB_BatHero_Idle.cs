using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_BatHero_Idle : CharacterStateMachineBehavior
{
    private float horizontalMovement;


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        
        playerCharacter.canControlMovement = false;
        
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
