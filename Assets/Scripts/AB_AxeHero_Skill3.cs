using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_AxeHero_Skill3 : CharacterStateMachineBehavior
{
    public AnimationClip groundForm;
    public AnimationClip jumpForm;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
        base.OnStateEnter(animator, stateInfo, layerIndex);
        
        if (!playerCharacter.isGrounded)
        {
            AnimatorOverrideController aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
 
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(groundForm, jumpForm));
 
            aoc.ApplyOverrides(anims);
            animator.runtimeAnimatorController = aoc;
        }
        else
        {
            AnimatorOverrideController aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
 
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(jumpForm, groundForm));
 
            aoc.ApplyOverrides(anims);
            animator.runtimeAnimatorController = aoc;
        }
        
        playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.GetComponent<AxeHeroAttackMessager>().hugeSlash.StopDetectTarget();
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
