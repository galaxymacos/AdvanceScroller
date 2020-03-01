using System;
using UnityEngine;

public class SMB_AxeHero_TryCatch : CharacterStateMachineBehavior
{
    private Rigidbody2D rb;
    [SerializeField] private float dashForce;
    private float dashForceCounter;
    [SerializeField] private float timeToCatch = 1f;
    private float timeToCatchCounter;
    // private bool isPausing;
    
    // Component
    private PausableSMB pauseableSMB;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        if (pauseableSMB == null)
        {
            pauseableSMB = new PausableSMB(this);
        }
        pauseableSMB.Pause();
        
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        playerCharacter.onCatchingSuccess += TransferToThrowState;
        playerCharacter.GetComponent<AxeHeroAttackMessager>().StartDetectingCatch();
        playerCharacter.GetComponent<UniqueSkillComponent>().ShowOff();

        
        timeToCatchCounter = timeToCatch;
        dashForceCounter = dashForce;
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        base.OnStateUpdate(animator, stateInfo, layerIndex);
        
        if (pauseableSMB.IsPausing) return;
        
        timeToCatchCounter -= Time.deltaTime;

        float t = Time.deltaTime / timeToCatch;
        dashForceCounter = Mathf.Lerp(dashForceCounter, 0, t);
        
        rb.velocity = playerCharacter.isFacingRight ? new Vector2(dashForceCounter, 0) : new Vector2(-dashForceCounter, 0);

        if (timeToCatchCounter <= 0)
        {
            characterAnimator.SetTrigger("idle");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        playerCharacter.GetComponent<AxeHeroAttackMessager>().StopDetectingCatch();
        playerCharacter.onCatchingSuccess -= TransferToThrowState;
        playerCharacter.GetComponent<UniqueSkillComponent>().End();
        rb.gravityScale = 1;
    }

    private void TransferToThrowState()
    {
        characterAnimator.SetTrigger("caught");
    }
    
 
}