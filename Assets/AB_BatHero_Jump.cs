using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_BatHero_Jump : CharacterStateMachineBehavior
{
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo,layerIndex);
        RegisterInputToNextState(new List<string> {"double jump", "dash", "jump attack","skill3","skill2","skill4"});
        playerCharacter = _animator.GetComponent<PlayerCharacter>();
        rb = _animator.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        playerCharacter.onPlayerStartJump?.Invoke();
        playerCharacter.onPlayerWalkNextToWall += TransferToWallSlide;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        playerCharacter.canControlMovement = true;

        _animator.GetComponent<PlayerCharacter>().characterGroundMovementComponent.UpdateMovement();

        
        
        
        if (rb.velocity.y < 0)
        {
            _animator.SetTrigger("fall down");
        }

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        playerCharacter.onPlayerWalkNextToWall -= TransferToWallSlide;

    }
}
