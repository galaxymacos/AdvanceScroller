using System;
using UnityEngine;

public class SMB_AxeHero_TryCatch : CharacterStateMachineBehavior, IPauseable
{
    private Rigidbody2D rb;
    [SerializeField] private float dashForce;
    private float dashForceCounter;
    [SerializeField] private float dashSpeedDecreaseRate = 0.3f;
    [SerializeField] private float timeToCatch = 1f;
    private float timeToCatchCounter;
    private bool isPausing;
    
    


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        playerCharacter.onCatchingSuccess += TransferToThrowState;
        playerCharacter.GetComponent<AxeHeroAttackMessager>().StartDetectingCatch();
        
        doPausing();
        timeToCatchCounter = timeToCatch;
        dashForceCounter = dashForce;
    }

    private void doPausing()
    {
        playerCharacter.GetComponent<CharacterPauser>().onCharacterPaused += Pause;
        playerCharacter.GetComponent<CharacterPauser>().onCharacterResumed += UnPause;
        playerCharacter.GetComponent<UniqueSkillComponent>().ShowOff();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        base.OnStateUpdate(animator, stateInfo, layerIndex);
        
        if (isPausing) return;
        
        timeToCatchCounter -= Time.deltaTime;

        float t = Time.deltaTime / timeToCatch;
        dashForceCounter = Mathf.Lerp(dashForceCounter, 0, t);
        
        if (playerCharacter.isFacingRight)
        {
            rb.velocity = new Vector2(dashForceCounter, 0);
        }
        else
        {
            rb.velocity = new Vector2(-dashForceCounter, 0);
        }

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
        
        playerCharacter.GetComponent<CharacterPauser>().onCharacterPaused -= Pause;
        playerCharacter.GetComponent<CharacterPauser>().onCharacterResumed -= UnPause;
    }

    private void TransferToThrowState()
    {
        characterAnimator.SetTrigger("caught");
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
    public void Pause()
    {
        isPausing = true;
        playerCharacter.PrintString(
            "pause pause pause pause pause pause pause pause pause pause pause pause pause pause pause pause pause pause");
    }

    public void UnPause()
    {
        playerCharacter.PrintString(
            "pause pause pause pause pause pause pause pause pause pause pause pause pause pause pause pause pause pause");
        isPausing = false;
    }
}
