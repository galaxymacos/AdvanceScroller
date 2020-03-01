using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_AxeHero_Caught : CharacterStateMachineBehavior
{

    private PlayerThrowMessager throwMessager;
    private PlayerCharacter playerToThrow;
    private Rigidbody2D rb;

    private PlayerThrowMessager damageAnalyzer;

    private List<Collider2D> collidersIgnored;

    [SerializeField] private DamageData stunDamageData;
    [SerializeField] private DamageData pushDamageData;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        shouldThrow = false;
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        
        // Get the player who should be thrown
        throwMessager = playerCharacter.GetComponent<PlayerThrowMessager>();
        playerToThrow = throwMessager.PlayerToThrow;
        
        playerToThrow.canControlMovement = false;
        playerToThrow.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerCharacter.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerToThrow.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerToThrow.GetComponent<DamageReceiver>().Analyze(stunDamageData, playerCharacter.transform);
        playerToThrow.transform.localScale = new Vector3(playerToThrow.transform.localScale.x, -playerToThrow.transform.localScale.y, playerToThrow.transform.localScale.z);


        playerCharacter.GetComponent<Rigidbody2D>().freezeRotation = false;
        playerToThrow.GetComponent<Rigidbody2D>().freezeRotation = false;

        collidersIgnored = new List<Collider2D>();

        var playerCollider = playerCharacter.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in playerCollider)
        {
            if (collider.enabled)
            {
                collidersIgnored.Add(collider);
                collider.enabled = false;
            }
        }
        var playerToThrowCollider = playerToThrow.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in playerToThrowCollider)
        {
            if (collider.enabled)
            {
                collidersIgnored.Add(collider);
                collider.enabled = false;
            }
        }
    }

    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        
        playerCharacter.transform.Rotate(Vector3.forward,720*Time.deltaTime);
        playerToThrow.transform.position = throwMessager.HeadTransform.position;

        if (playerInput.skill4ButtonPressed)
        {
            playerInput.skill4ButtonPressed = false;
            // var throwAngle = Vector3.Normalize(playerToThrow.transform.position - playerCharacter.transform.position);
            characterAnimator.SetTrigger("idle");
            shouldThrow = true;
        }
    }

    private bool shouldThrow;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerToThrow.canControlMovement = true;
        playerCharacter.GetComponent<Rigidbody2D>().gravityScale = 1;
        playerToThrow.GetComponent<Rigidbody2D>().gravityScale = 1;
        playerToThrow.transform.localScale = new Vector3(playerToThrow.transform.localScale.x, -playerToThrow.transform.localScale.y, playerToThrow.transform.localScale.z);

        playerCharacter.GetComponent<Rigidbody2D>().freezeRotation = true;
        playerToThrow.GetComponent<Rigidbody2D>().freezeRotation = true;
        playerCharacter.transform.rotation = Quaternion.Euler(playerCharacter.transform.rotation.x,playerCharacter.transform.rotation.y,0);
        playerToThrow.transform.rotation = Quaternion.Euler(playerToThrow.transform.rotation.x,playerToThrow.transform.rotation.y,0);

        foreach (var colliderIgnored in collidersIgnored)
        {
            colliderIgnored.enabled = true;

        }

        if (shouldThrow)
        {
            playerToThrow.GetComponent<DamageReceiver>().Analyze(pushDamageData, playerCharacter.transform);
        }

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
