using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_Stomp_General : CharacterStateMachineBehavior
{
    public float stompSpeed = 12f;

    private Rigidbody2D rb;

    private float postSkillTime = 0.5f;
    private float postSkillTimeCounter;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        
        rb.velocity = Vector2.down * stompSpeed;
        playerCharacter.onPlayerGrounded += SpawnImpactWave;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (postSkillTimeCounter > 0)
        {
            postSkillTimeCounter -= Time.deltaTime;
            if (postSkillTimeCounter <= 0)
            {
                animator.SetTrigger("idle");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
       
        playerCharacter.StopImpactWave();
        playerCharacter.onPlayerGrounded -= SpawnImpactWave;
    }

    public void SpawnImpactWave()
    {
        playerCharacter.SpawnImpactWave();
        postSkillTimeCounter = postSkillTime;
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
