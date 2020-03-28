using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Bandit_Run : SMB_Bandit
{
    private float RunSpeed => data.alertTimeCounter > 0 ? baseRunSpeed * runSpeedMultiplier : baseRunSpeed;
     private float baseRunSpeed = 3f;
    [SerializeField] private float runSpeedMultiplier = 3f;
    [SerializeField] private float timeBeforeExhausted = 3f;
    private bool isFacingRight;
    private float timeBeforeExhaustedCounter;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        timeBeforeExhaustedCounter = timeBeforeExhausted;
        isFacingRight = facingComponent.IsFacingRight;
        rigidbody.velocity = isFacingRight ? new Vector3(RunSpeed, rigidbody.velocity.y) : new Vector3(-RunSpeed, rigidbody.velocity.y);
        eventSystem.goToNearEdge += TurnAround;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (facingComponent.IsFacingRight)
        {
            rigidbody.velocity = new Vector3(RunSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector3(-RunSpeed, rigidbody.velocity.y);
        }

        if (timeBeforeExhaustedCounter > 0)
        {
            timeBeforeExhaustedCounter-=Time.deltaTime;
            if (timeBeforeExhaustedCounter <= 0)
            {
                if (actionLimiter.CanGoToAnimation("Idle"))
                {
                    animator.SetTrigger("Idle");
                }
                else if (actionLimiter.CanGoToAnimation("Jump"))
                {
                    animator.SetTrigger("Jump");
                }
            }
        }

        if (attackRangeDetector.TargetPlayer != null)
        {
            if (actionLimiter.CanGoToAnimation("Attack"))
            {
                anim.SetTrigger("Attack");
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        rigidbody.velocity = Vector3.zero;
        eventSystem.goToNearEdge -= TurnAround;
    }

    private void TurnAround()
    {
        if (Random.Range(0, 2) == 1)
        {
            if (actionLimiter.CanGoToAnimation("Jump"))
            {
                Debug.Log("jump");
                anim.SetTrigger("Jump");
            }
            else
            {
                Debug.Log("not jump");
                rigidbody.velocity = new Vector3(-rigidbody.velocity.x, rigidbody.velocity.y);
            }
        }
        else
        {
            Debug.Log("not jump");
            rigidbody.velocity = new Vector3(-rigidbody.velocity.x, rigidbody.velocity.y);
        }
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
