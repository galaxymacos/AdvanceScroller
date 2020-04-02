﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_BatHero_BatFly : CharacterStateMachineBehavior
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerInput.skill1ButtonPressed = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        rb.velocity = new Vector2(playerInput.horizontalAxis, playerInput.verticalAxis)*5;
        if (playerInput.skill1ButtonPressed == false)
        {
            animator.SetTrigger("fall down");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

}
