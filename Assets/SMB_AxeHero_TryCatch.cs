using UnityEngine;

public class SMB_AxeHero_TryCatch : CharacterStateMachineBehavior
{
    private Rigidbody2D rb;
    [SerializeField] private float dashForce;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerCharacter.GetComponent<UniqueSkillComponent>().ShowOff();
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        playerCharacter.onCatchingSuccess += TransferToThrowState;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        
        if (playerCharacter.isFacingRight)
        {
            rb.velocity = new Vector2(dashForce, 0);
        }
        else
        {
            rb.velocity = new Vector2(-dashForce, 0);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        playerCharacter.onCatchingSuccess -= TransferToThrowState;
        playerCharacter.GetComponent<UniqueSkillComponent>().End();
        rb.gravityScale = 1;
    }

    private void TransferToThrowState()
    {
        characterAnimator.SetTrigger("throw");
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
