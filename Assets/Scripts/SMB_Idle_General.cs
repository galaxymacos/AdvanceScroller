using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Idle_General : CharacterStateMachineBehavior
{
    private float horizontalMovement;

    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo, layerIndex);
        playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
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
