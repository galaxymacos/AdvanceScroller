using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_Climb_General : CharacterStateMachineBehavior
{
    
    public float climbSpeed = 5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerCharacter.onPlayerExitLadder += TransferToIdleState;
        playerCharacter.onPlayerGrounded += TransferToIdleState;
        playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerCharacter.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerInput.horizontalAxis = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (playerInput.verticalAxis > Mathf.Epsilon)
        {
            playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector2.up * climbSpeed;
            animator.speed = 1;
        }
        else if (playerInput.verticalAxis < -Mathf.Epsilon)
        {
            playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector2.down * climbSpeed;
            animator.speed = 1;
        }
        else
        {
            playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            animator.speed = 0;
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        playerCharacter.GetComponent<Rigidbody2D>().gravityScale = 1;
        playerCharacter.onPlayerExitLadder -= TransferToIdleState;
        playerCharacter.onPlayerGrounded -= TransferToIdleState;
        animator.speed = 1;
        playerInput.verticalAxis = 0;

    }

    public void TransferToIdleState()
    {
        characterAnimator.SetTrigger("idle");
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
