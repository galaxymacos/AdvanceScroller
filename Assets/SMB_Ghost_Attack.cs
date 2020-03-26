using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Ghost_Attack : GhostStateMachineBehavior
{
    private float velocityMultiplier = 2.5f;
    private Vector3 originalVelocity;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        ghostStats.lastAttackTime = Time.time;
        originalVelocity = rigidbody.velocity;
        rigidbody.velocity *= velocityMultiplier;
        ghostFacingComponent.SetFacingDelegate(GhostFacingComponent.FacingCondition.FaceByRelativePosition);
        
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        ghostFacingComponent.SetFacingDelegate(GhostFacingComponent.FacingCondition.FaceByVelocity);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        rigidbody.velocity = Vector2.zero;
        animator.SetTrigger(ghostScoreSystem.GetNextAction());
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
