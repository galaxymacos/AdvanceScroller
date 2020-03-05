﻿using System.Collections;
using UnityEngine;

public class AB_Hurt_General : CharacterStateMachineBehavior
{
    private Rigidbody2D rb;

    private Knockable knockable;
    [Tooltip("Dash when getting hit in 0.05 seconds to get out of the hurt state and dash")]
    private float dashStillAllowedLimit = 0.15f;
    private float dashStillAlowedTimeCounter = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rb = animator.GetComponent<Rigidbody2D>();
        knockable = animator.GetComponent<Knockable>();
        rb.velocity = knockable.knockDirection;
        dashStillAlowedTimeCounter = dashStillAllowedLimit;
    }
 
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (dashStillAlowedTimeCounter > 0)
        {
            dashStillAlowedTimeCounter -= Time.deltaTime;
            if (playerInput!=null && playerInput.dashButtonPressed)
            {
                playerInput.dashButtonPressed = false;
                BulletTimeManager.instance.Register(0.15f);
                ShaderProcessor.instance.Blur(playerCharacter.GetComponent<SpriteRenderer>());
                // playerCharacter.PrintString("trying to dash");
                animator.SetTrigger("dash");
                playerCharacter.dashInvincibleTimeCounter = playerCharacter.dashInvincibleTime;
            }
        }
        if(playerCharacter.isGrounded && rb.velocity.y <= 0)
            animator.SetTrigger("idle");
        
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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