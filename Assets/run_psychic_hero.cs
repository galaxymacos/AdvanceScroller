using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run_psychic_hero : StateMachineBehaviour
{
    private PsychicHeroMessagingSystem messagingSystem;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        messagingSystem = animator.GetComponent<PsychicHeroMessagingSystem>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        messagingSystem.canMove = true;



        if (messagingSystem.heroInput.horizontalAxis > -Mathf.Epsilon && messagingSystem.heroInput.horizontalAxis < Mathf.Epsilon)
        {
            animator.SetTrigger("idle");
        }

        if (messagingSystem.heroInput.attackButtonPressed)
        {
            messagingSystem.heroInput.attackButtonPressed = false;
            animator.SetTrigger("attack");
        }
        
        if (messagingSystem.heroInput.jumpButtonPressed)
        {
            messagingSystem.heroInput.jumpButtonPressed = false;
            animator.SetTrigger("jump");
        }

        if (!messagingSystem.isGrounded)
        {
            animator.SetTrigger("fall down");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
