using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : CharacterStateMachineBehavior
{
    private Rigidbody2D rb;
    private PushComponent pushComponent;

    private bool hasHitCollision;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        pushComponent = animator.GetComponent<PushComponent>();
        pushComponent.onHitGround += BounceFromGround;
        pushComponent.onHitWall += BounceFromWall;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (!hasHitCollision)
        {
            rb.velocity = pushComponent.pushDirection * pushComponent.pushSpeed;
        }
    }

    private void BounceFromWall(Vector2 collisionPoint)
    {
        hasHitCollision = true;
        var vectorAfterBounce = new Vector2(-rb.velocity.x, rb.velocity.y);
        rb.velocity = vectorAfterBounce + Vector2.up * 5;
    }

    private void BounceFromGround(Vector2 collisionPoint)
    {
        hasHitCollision = true;
        var vectorAfterBounce = new Vector2(rb.velocity.x, -rb.velocity.y);
        rb.velocity = vectorAfterBounce;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        pushComponent.onHitGround -= BounceFromGround;
        pushComponent.onHitWall -= BounceFromWall;
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