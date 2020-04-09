﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Jump_General : CharacterStateMachineBehavior
{

    [SerializeField] private AnimationClip firstJump;
    [SerializeField] private AnimationClip secondJump;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo, layerIndex);

        if (playerCharacter.jumpTime == 0)
        {
            AnimatorOverrideController aoc = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(secondJump, firstJump));
        
            aoc.ApplyOverrides(anims);
            _animator.runtimeAnimatorController = aoc;
        }
        else
        {
            AnimatorOverrideController aoc = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(firstJump, secondJump));
        
            aoc.ApplyOverrides(anims);
            _animator.runtimeAnimatorController = aoc;
        }

        playerCharacter = _animator.GetComponent<PlayerCharacter>();
        rb = _animator.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, playerCharacter.GetJumpSpeed());


        playerCharacter.jumpTime++;
        playerCharacter.onPlayerStartJump?.Invoke();
        playerCharacter.onPlayerWalkNextToWall += TransferToWallSlide;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);

        _animator.GetComponent<PlayerCharacter>().characterGroundMovementComponent.UpdateMovement();


        if (rb.velocity.y < 0)
        {
            _animator.SetTrigger("fall down");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        playerCharacter.onPlayerWalkNextToWall -= TransferToWallSlide;
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