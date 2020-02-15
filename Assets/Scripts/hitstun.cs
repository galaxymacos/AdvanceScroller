using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitstun : CharacterStateMachineBehavior
{
    private StunComponent stunComponent;
    private Rigidbody2D rb;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerCharacter.canControlMovement = false;
        stunComponent = animator.GetComponent<StunComponent>();
        stunComponent.onstunEnd += TransferToIdle;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    private void TransferToIdle()
    {
        characterAnimator.SetTrigger("idle");
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = Vector2.zero;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        stunComponent.onstunEnd -= TransferToIdle;
        playerCharacter.canControlMovement = true;
        if (playerCharacter.GetComponent<CharacterHealthComponent>().isPlayerDead)
        { 
            animator.SetTrigger("die");
        }

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
