using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce_back : CharacterStateMachineBehavior
{
    private Rigidbody2D rb;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo,layerIndex);
        playerCharacter = _animator.GetComponent<PlayerCharacter>();
        rb = _animator.GetComponent<Rigidbody2D>();
        Vector2 pushDirection = Vector3.Normalize(playerCharacter.GetComponent<PushComponent>().pushDirection) *
                                playerCharacter.GetComponent<PushComponent>().pushSpeed;
        rb.AddForce(new Vector2(-1000, 1000));

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

    }
}
