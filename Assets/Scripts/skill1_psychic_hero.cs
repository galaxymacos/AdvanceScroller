using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill1_psychic_hero : CharacterStateMachineBehavior
{
    public float maxChargedTime = 1.5f;

    private float chargedTimeCounter;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerCharacter.canControlMovement = false;
        playerInput.skill1ButtonPressed = true;
        chargedTimeCounter = 0;
        playerCharacter.GetComponent<Rigidbody2D>().gravityScale = 0;
        // animator.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        chargedTimeCounter += Time.deltaTime;
        if (!playerInput.skill1ButtonPressed)
        {
            if (chargedTimeCounter >= maxChargedTime)
            {
                animator.SetTrigger("throw axe charged");
            }
            else
            {
                animator.SetTrigger("throw axe");
            }
        }
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        animator.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        playerCharacter.GetComponent<Rigidbody2D>().gravityScale = 1;
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
