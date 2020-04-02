using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Hitstun_General : CharacterStateMachineBehavior
{
    private StunComponent stunComponent;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        stunComponent = animator.GetComponent<StunComponent>();
        stunComponent.onstunEnd += TransferToIdle;
    }

    private void TransferToIdle()
    {
        characterAnimator.SetTrigger("idle");
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        rb.velocity = Vector2.zero;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        stunComponent.onstunEnd -= TransferToIdle;
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
