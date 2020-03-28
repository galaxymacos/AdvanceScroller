using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SMB_Bandit_Jump : SMB_Bandit
{
    private Collider[] colliders;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        colliders = animator.GetComponents<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        Vector2 jumpPointLocation = FindClosestJumpingPointToPlayer();
        rigidbody.gravityScale = 0f;
        
        data.jumpingTimeCounter--;
        animator.transform.DOJump(jumpPointLocation, 4, 1, 1).OnComplete(NextAction);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        rigidbody.gravityScale = 1f;
    }

    private Vector2 FindClosestJumpingPointToPlayer()
    {
        Transform[] jumpingPoints = data.jumpingPoints;
        Transform randomJumpingPoints = jumpingPoints[Random.Range(0, jumpingPoints.Length)];
        return randomJumpingPoints.position;
    }

    public void NextAction()
    {
        
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
        
        if (data.jumpingTimeCounter <= 0)
        {
            if (actionLimiter.CanGoToAnimation("DashStrike"))
            {
                data.jumpingTimeCounter = data.maxJumpingTime;
                anim.SetTrigger("DashStrike");
            }
        }
        else
        {
            if (actionLimiter.CanGoToAnimation("Jump"))
            {
                
                anim.SetTrigger("Jump");
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
