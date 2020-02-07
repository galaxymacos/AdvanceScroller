using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash_psychic_hero : StateMachineBehaviour
{
    [SerializeField] private float dashSpeed = 5;

    [SerializeField] private float dashDuration = 0.5f;

    private float dashTimeCounter;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dashTimeCounter = dashDuration;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dashTimeCounter -= Time.deltaTime;
        if (dashTimeCounter <= 0)
        {
            animator.SetTrigger("idle");
        }
        animator.GetComponent<PsychicHeroMessagingSystem>().canMove = false;
        Rigidbody2D rb = animator.GetComponent<Rigidbody2D>();
        if (animator.GetComponent<PsychicHeroMessagingSystem>().isFacingRight)
        {
            rb.velocity = Vector2.right*dashSpeed;
        }
        else
        {
            rb.velocity = -Vector2.right*dashSpeed;

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PsychicHeroMessagingSystem>().canMove = true;
        
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
