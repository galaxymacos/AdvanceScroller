using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_AxeHero_Idle : CharacterStateMachineBehavior
{
    private float horizontalMovement;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(_animator, stateInfo, layerIndex);
        RegisterInputToNextState(new List<string> {"attack", "run", "dash", "jump", "skill1", "skill2", "skill3", "skill4"});     // TODO
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(_animator, stateInfo, layerIndex);
        
        playerCharacter.canControlMovement = false;
        
        if (!playerCharacter.isGrounded)
        {
            _animator.SetTrigger("fall down");
        }

        if (playerCharacter.isDead)
        {
            _animator.SetTrigger("die");
        }
        
    }
}
