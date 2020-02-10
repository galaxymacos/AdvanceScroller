using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_psychic_hero : CharacterStateMachineBehavior
{
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo,layerIndex);
        RegisterInputToNextState(new List<string> {"double jump", "dash", "jump attack","skill3"});
        playerCharacter = _animator.GetComponent<PlayerCharacter>();
        rb = _animator.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        playerCharacter.SpawnGroundDustTwoWays();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        playerCharacter.canMove = true;

        _animator.GetComponent<PlayerCharacter>().characterGroundMovementComponent.UpdateMovement();

        
        
        
        if (rb.velocity.y < 0)
        {
            _animator.SetTrigger("fall down");
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


