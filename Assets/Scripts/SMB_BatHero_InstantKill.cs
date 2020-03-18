using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_BatHero_InstantKill : CharacterStateMachineBehavior
{
    private Rigidbody2D rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        
        playerCharacter.GetComponent<UltimateComponent>().ShowOff();
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("reach 0");
        base.OnStateExit(animator, stateInfo, layerIndex);

        animator.GetComponent<BatHeroAttackMessager>().instantKill.StopDetectTargetManually();
        Debug.Log("reach 1");
        rb.gravityScale = 1;
        Debug.Log("reach 2");
        animator.GetComponent<UltimateComponent>().End();

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