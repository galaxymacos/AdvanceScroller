using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_psychic_hero : StateMachineBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    private PsychicHeroMessagingSystem messagingSystem;
    private Rigidbody2D rb;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        messagingSystem = animator.GetComponent<PsychicHeroMessagingSystem>();
        rb = animator.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        messagingSystem.canMove = true;

        
        animator.GetComponent<PsychicHeroMessagingSystem>().psychicHeroHorizontalMovementComponent.UpdateMovement();
        
        if (messagingSystem.heroInput.jump)
        {
            animator.SetTrigger("double jump");
        }

        if (rb.velocity.y < 0)
        {
            animator.SetTrigger("fall down");
        }

        
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


