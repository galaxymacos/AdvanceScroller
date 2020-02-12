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
        base.OnStateEnter(animator, stateInfo, layerIndex);
        RegisterInputToNextState(new List<string> {"attack", "run", "dash", "jump", "skill1", "skill2", "skill3", "skill4"});     // TODO

        rb = playerCharacter.GetComponent<Rigidbody2D>();
        pushComponent = animator.GetComponent<PushComponent>();
        pushComponent.onHitWall += BounceFromWall;
        playerCharacter.canControlMovement = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (!hasHitCollision)
        {
            rb.velocity = pushComponent.pushDirection * pushComponent.pushSpeed;
        }
        // else
        // {
            // var vectorAfterBounce = new Vector2(-pushComponent.pushDirection.x, 4);
            // rb.velocity = vectorAfterBounce;
        // }

        if (hasHitCollision && playerCharacter.isGrounded && rb.velocity.y <=0)
        {
            animator.SetTrigger("idle");
        }
    }

    private void BounceFromWall(Vector2 collisionPoint)
    {
        rb.velocity = new Vector2(-4, 5);
        // animator.SetTrigger("fall down");
        hasHitCollision = true;
    }

    private void BounceFromGround(Vector2 collisionPoint)
    {
        hasHitCollision = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        pushComponent.onHitGround -= BounceFromGround;
        pushComponent.onHitWall -= BounceFromWall;
        hasHitCollision = false;
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