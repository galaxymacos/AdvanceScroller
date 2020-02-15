using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_AxeHero_Attack : CharacterStateMachineBehavior
{
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        RegisterInputToNextState(new List<string> {"jump"});     // TODO

        // if (playerCharacter.isGrounded)
        // {
            playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            playerCharacter.canControlMovement = false;
        // }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
        
    // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCharacter.GetComponent<AxeHeroAttackMessager>().attack.StopDetectTarget();
        playerCharacter.canControlMovement = true;
    }
}
