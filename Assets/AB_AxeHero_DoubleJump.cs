using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_AxeHero_DoubleJump : CharacterStateMachineBehavior
{
    [SerializeField] private float jumpForce = 5;
    private Rigidbody2D rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo, layerIndex);
        RegisterInputToNextState(new List<string> {"attack","skill2","dash"});
        playerCharacter.hasDoubleJump = true;
        rb = _animator.GetComponent<Rigidbody2D>();

        
        playerCharacter.canControlMovement = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        playerCharacter.onPlayerStartDoubleJump?.Invoke();
        

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        if (playerCharacter.isGrounded)
        {
            _animator.SetTrigger("idle");
        }
        
        if (rb.velocity.y < 0)
        {
            _animator.SetTrigger("fall down");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

    }
}
