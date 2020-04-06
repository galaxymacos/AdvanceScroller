using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Ghost_Chase : GhostStateMachineBehavior
{
    


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        ghostFacingComponent.SetFacingDelegate(GhostFacingComponent.FacingCondition.FaceByRelativePosition);
        ghostStats.interestPointInChasingCounter = ghostStats.maxInterestPointInChasing;
        Debug.Log("enter chasing state");

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (GameStateMachine.gameIsPause) return;
        Chase();
        PlayNextActionWhenCloseToAttackRange();
        
        if (ghostStats.interestPointInChasingCounter > 0)
        {
            ghostStats.interestPointInChasingCounter -= Time.deltaTime*ghostStats.interestPointToLoseInChasingPerSec;
            if (ghostStats.interestPointInChasingCounter <= 0)
            {
                Debug.Log($"tend to lose interest to player because of haven't caught player in {ghostStats.maxInterestPointInChasing} seconds");
                animator.SetTrigger(ghostScoreSystem.GetNextAction());
            }
        }

        
        if (PassDistanceLimit())
        {
            Debug.Log($"tend to lose interest to player because of player is out of the range");
            animator.SetTrigger(ghostScoreSystem.GetNextAction());
        }

        if (ghostStats.distractIntervalInChasingCounter > 0)
        {
            ghostStats.distractIntervalInChasingCounter-=Time.deltaTime;
            if (ghostStats.distractIntervalInChasingCounter <= 0)
            {
                Debug.Log($"tend to lose interest to player because of player ghost get distracted ");
                ghostStats.distractIntervalInChasingCounter = ghostStats.maxDistractIntervalInChasing;
                animator.SetTrigger(ghostScoreSystem.GetNextAction());
            }
        }
        
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        ghostStats.interestPointInChasingCounter = ghostStats.maxInterestPointInChasing;
    }

    private bool PassDistanceLimit()
    {
        return Vector3.Distance(ghostStats.playerToChase.transform.position, transform.position) > ghostStats.rangeToLoseInterestInChasing;
    }
    private void Chase()
    {
        Vector3 direction = Vector3.Normalize(-transform.position + ghostStats.playerToChase.transform.position);
        rigidbody.velocity = direction * ghostStats.chaseSpeed;
    }

    private void PlayNextActionWhenCloseToAttackRange()
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