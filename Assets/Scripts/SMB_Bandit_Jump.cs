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
            if (!collider.isTrigger)
            {
                collider.enabled = false;
            }
        }
        Vector2 jumpPointLocation = FindClosestJumpingPointToPlayer();
        rigidbody.gravityScale = 0f;
        
        data.jumpingTimeCounter--;
        animator.transform.DOJump(jumpPointLocation, 4, 1, 1).OnComplete(NextAction);
            if (jumpPointLocation.x > animator.transform.position.x &&
                !facingComponent.IsFacingRight)
            {
                facingComponent.ChangeFacing();
            }
            else if (jumpPointLocation.x < animator.transform.position.x &&
                     facingComponent.IsFacingRight)
            {
                facingComponent.ChangeFacing();
            }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        rigidbody.gravityScale = 1f;
    }

    private Vector2 FindClosestJumpingPointToPlayer()
    {
        Transform[] jumpingPoints;
        if (data.targetPlayer != null)
        {
            Debug.Log("Jumping point near player");
            jumpingPoints = data.dataInquirer.NearJumpingPointsToPosition(data.targetPlayer.transform.position,data.jumpingPoints, 2);
        }
        else
        {
            Debug.Log("Jumping point random");
            jumpingPoints = data.jumpingPoints.ToArray();
        }
        Transform randomJumpingPoints = jumpingPoints[Random.Range(0, jumpingPoints.Length)];
        return randomJumpingPoints.position;
    }

    public void NextAction()
    {
        
        foreach (Collider collider in colliders)
        {
            if (!collider.isTrigger)
            {
                collider.enabled = true;
            }
        }
        
        if (data.jumpingTimeCounter <= 0)
        {
            if (actionLimiter.CanGoToAnimation("DashStrike"))
            {
                data.jumpingTimeCounter = Random.Range(1,data.maxJumpingTime+1);
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
