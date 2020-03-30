using System.Collections;
using UnityEngine;

public class AB_Hurt_General : CharacterStateMachineBehavior
{
    private AudioType dashAttemptSucceeded;
    private AudioType dashAttemptFailed;
    private Knockable knockable;
    [Tooltip("Dash when getting hit in 0.1 seconds to get out of the hurt state and dash")]
    private float dashStillAllowedLimit = 0.1f;
    private float dashStillAlowedTimeCounter = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        knockable = animator.GetComponent<Knockable>();
        rb.velocity = knockable.knockDirection;
        dashStillAlowedTimeCounter = dashStillAllowedLimit;
    }
 
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (dashStillAlowedTimeCounter > 0)
        {
            dashStillAlowedTimeCounter -= Time.deltaTime;
            var energyComponent = playerCharacter.GetComponent<CharacterEnergyComponent>();
            if (playerInput!=null && playerInput.dashButtonPressed && energyComponent.IsFull)
            {
                energyComponent.Consume(energyComponent.currentEnergy);
                playerInput.dashButtonPressed = false;
                BulletTimeManager.instance.Register(0.3f);
                playerCharacter.dashInvincibleTimeCounter = playerCharacter.dashInvincibleTime;
                playerCharacter.onDashOutFromHurt?.Invoke();
                animator.SetTrigger("dash");
                

            }
        }
        if(playerCharacter.IsGrounded && rb.velocity.y <= 0)
            animator.SetTrigger("idle");
        
    }

    
}