using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Idle_General : CharacterStateMachineBehavior
{
    private float horizontalMovement;
    private Rigidbody2D rb;

    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo, layerIndex);
        rb = _animator.GetComponent<Rigidbody2D>();
        rb.velocity.Set(0,rb.velocity.y);
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
