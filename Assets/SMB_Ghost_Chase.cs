using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Ghost_Chase : GhostStateMachineBehavior
{
    public float timeToLoseInterest = 5f;
    private float timeToLoseInterestCounter;
    public bool isLoseInterest => timeToLoseInterest <= 0f;
    public float rangeToLoseInterest = 15;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        timeToLoseInterestCounter = timeToLoseInterest;
        ghostFacingComponent.SetFacingDelegate(GhostFacingComponent.FacingCondition.FaceByRelativePosition);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (timeToLoseInterestCounter > 0)
        {
            timeToLoseInterestCounter -= Time.deltaTime;
            if (timeToLoseInterestCounter <= 0)
            {
                animator.SetTrigger(ghostScoreSystem.GetNextAction());
            }
        }

        Chase();
        AttackIfCloseToAttackRange();
        if (PassDistanceLimit())
        {
            animator.SetTrigger(ghostScoreSystem.GetNextAction());
        }
        
        
    }
    private bool PassDistanceLimit()
    {
        return Vector3.Distance(ghostStats.playerToChase.transform.position, transform.position) > rangeToLoseInterest;
    }
    private void Chase()
    {
        Vector3 direction = Vector3.Normalize(-transform.position + ghostStats.playerToChase.transform.position);
        rigidbody.velocity = direction * ghostStats.chaseSpeed;
    }

    private void AttackIfCloseToAttackRange()
    {
        if (Vector3.Distance(ghostStats.playerToChase.transform.position, transform.position) <= ghostStats.attackRange)
        {
            anim.SetTrigger(ghostScoreSystem.GetNextAction());
        }
    }
    
    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

}