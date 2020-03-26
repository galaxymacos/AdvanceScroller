﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_BatHero_InstantKill : CharacterStateMachineBehavior
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        
        playerCharacter.GetComponent<UltimateComponent>().ShowOff();
        rb.gravityScale = 0;
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        animator.GetComponent<BatHeroAttackMessager>().instantKill.StopDetectTargetManually();
        rb.gravityScale = 1;
        animator.GetComponent<UltimateComponent>().End();
        playerInput.horizontalAxis = 0;

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