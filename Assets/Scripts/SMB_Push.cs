using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Push : CharacterStateMachineBehavior
{
    private Rigidbody2D rb;
    private PushComponent pushComponent;
    private bool groundedOnInitialization;
    private Vector3 originalPos;
    private bool hasHitCollision;

    public DamageData bounceBackDamageData;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        rb = playerCharacter.GetComponent<Rigidbody2D>();
        pushComponent = animator.GetComponent<PushComponent>();
        pushComponent.onHitWall += BounceFromWall;
        pushComponent.onHitGround += BounceFromGround;
        playerCharacter.canControlMovement = false;
        groundedOnInitialization = playerCharacter.isGrounded;
        hasHitCollision = false;
        originalPos = playerCharacter.transform.position;
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

        if (Vector3.Magnitude(playerCharacter.transform.position - originalPos) > pushComponent.pushDistance && !hasHitCollision)
        {
            rb.velocity = Vector3.zero;
            animator.SetTrigger("idle");
        }
    }

    private void BounceFromWall(Vector2 collisionPoint)
    {
            // if (pushComponent.pushDirection.x > 0)
            // {
                // rb.velocity = new Vector2(-4, 5);
            // }
            // else
            // {
                // rb.velocity = new Vector2(4, 5);
            // }
            hasHitCollision = true;
            pushComponent.onHitGround -= BounceFromGround;
            pushComponent.onHitWall -= BounceFromWall;
       
            DamageData bounceFromWallDamageData = CreateInstance<DamageData>();
            bounceFromWallDamageData.damage = 5;
            bounceFromWallDamageData.damageType = DamageType.Explosion;
            bounceFromWallDamageData.launcherVerticalForce = 5;
            bounceFromWallDamageData.launcherHorizontalForce = pushComponent.pushDirection.x > 0 ? -4 : 4;
            playerCharacter.GetComponent<DamageReceiver>().Analyze(bounceFromWallDamageData, playerCharacter.transform);    // The second param has no meaning
            characterAnimator.SetTrigger("hurt");
    }

    private void BounceFromGround(Vector2 collisionPoint)
    {
        if (groundedOnInitialization == false)
        {
            hasHitCollision = true;
            rb.velocity = new Vector2((pushComponent.pushDirection*pushComponent.pushSpeed).x, -(pushComponent.pushDirection*pushComponent.pushSpeed).y);
            pushComponent.onHitWall -= BounceFromWall;
            pushComponent.onHitGround -= BounceFromGround;
            
            hasHitCollision = true;
            pushComponent.onHitGround -= BounceFromGround;
            pushComponent.onHitWall -= BounceFromWall;
       
            DamageData bounceFromWallDamageData = CreateInstance<DamageData>();
            bounceFromWallDamageData.damage = 5;
            bounceFromWallDamageData.damageType = DamageType.Explosion;
            bounceFromWallDamageData.launcherVerticalForce = Mathf.Abs((pushComponent.pushDirection * pushComponent.pushSpeed).y);
            bounceFromWallDamageData.launcherHorizontalForce =
                (pushComponent.pushDirection * pushComponent.pushSpeed).x;
            playerCharacter.GetComponent<DamageReceiver>().Analyze(bounceFromWallDamageData, playerCharacter.transform);    // The second param has no meaning
            characterAnimator.SetTrigger("hurt");
        }
        
        
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        pushComponent.onHitGround -= BounceFromGround;
        pushComponent.onHitWall -= BounceFromWall;
        hasHitCollision = false;

        playerCharacter.canControlMovement = true;
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