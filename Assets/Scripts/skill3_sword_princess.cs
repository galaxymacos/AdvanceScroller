using System;
using System.Collections.Generic;
using UnityEngine;

public class skill3_sword_princess : CharacterStateMachineBehavior
{
    private Rigidbody2D rb;
    [SerializeField] private float startSpeed = 2f;
    [SerializeField] private float speedIncreaseFactor = 5f;
    private Vector2 startDirection;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo, layerIndex);
        startDirection = playerCharacter.isFacingRight ? Vector2.right : Vector2.left;
        rb = _animator.GetComponent<Rigidbody2D>();
        rb.velocity = startDirection * startSpeed;
        playerCharacter.GetComponent<AttackMessagingComponent>().DetectPierceAttack(1);
        rb.gravityScale = 0f;
        rb.freezeRotation = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 previousVelocity = rb.velocity;
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        bool shouldRotationReveresd = playerInput.verticalAxis < 0 ^ playerCharacter.isFacingRight;
        if (Math.Abs(playerInput.verticalAxis) > Mathf.Epsilon)
        {
            rb.velocity += new Vector2(Vector3.Cross( shouldRotationReveresd?Vector3.forward : Vector3.back, rb.velocity).x, Vector3.Cross(shouldRotationReveresd?Vector3.forward : Vector3.back, rb.velocity).y) * Time.deltaTime * 5;

        }

        float factorThisFrame = (speedIncreaseFactor * Time.deltaTime);
        var normal = rb.velocity.normalized;
        rb.velocity += normal * factorThisFrame;
        // if (playerInput.verticalAxis > 0)
        // {
        // }
        // else if(playerInput.verticalAxis < 0)
        // {
        //     Debug.Log("climbing down ");
        //     rb.velocity +=
        //         new Vector2(Vector3.Cross(Vector3.back, rb.velocity).x, Vector3.Cross(Vector3.back, rb.velocity).y) *
        //         Time.deltaTime * 5;
        //
        // }
        // playerCharacter.transform.rotation = Quaternion.LookRotation(rb.velocity);
        playerCharacter.transform.rotation = Quaternion.FromToRotation(previousVelocity,rb.velocity) * playerCharacter.transform.rotation;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.gravityScale = 1f;
        rb.freezeRotation = true;
        playerCharacter.transform.rotation = Quaternion.Euler(playerCharacter.transform.rotation.x,playerCharacter.transform.rotation.y,0);
        playerCharacter.GetComponent<AttackMessagingComponent>().DetectPierceAttack(0);
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
