using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Bandit_Idle : SMB_Bandit
{
    [SerializeField] AnimationClip idleAnimation;
    [SerializeField] AnimationClip combatIdleAnimation;
    [SerializeField] private float toPatrolTime = 3f;

    private float patrolTimeCounter;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        patrolTimeCounter = toPatrolTime;
        
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (data.targetPlayer!=null)
        {
            AnimatorOverrideController aoc = new AnimatorOverrideController(anim.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
 
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(idleAnimation, combatIdleAnimation));
 
            aoc.ApplyOverrides(anims);
            anim.runtimeAnimatorController = aoc;

        }
        else
        {
            AnimatorOverrideController aoc = new AnimatorOverrideController(anim.runtimeAnimatorController);
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
 
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(combatIdleAnimation, idleAnimation));
 
            aoc.ApplyOverrides(anims);
            anim.runtimeAnimatorController = aoc;

        }
        
        if (patrolTimeCounter > 0)
        {
            if (data.alertTimeCounter>0)
            {
                patrolTimeCounter -= Time.deltaTime * 3;
            }
            else
            {
                patrolTimeCounter -= Time.deltaTime;
            }
            if (patrolTimeCounter <= 0)
            {
                if (actionLimiter.CanGoToAnimation("Run"))
                {
                    animator.SetTrigger("Run");
                }
            }
        }
        
        if (attackRangeDetector.TargetPlayer != null)
        {
            if (actionLimiter.CanGoToAnimation("Attack"))
            {
                anim.SetTrigger("Attack");
                
            }
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

public class SMB_Bandit: StateMachineBehaviour
{
    protected FacingComponent2D facingComponent;
    protected BanditEventSystem eventSystem;
    protected Rigidbody2D rigidbody;
    protected BanditPlayerDetector banditPlayerDetector;
    protected BanditAttackRangeDetector attackRangeDetector;
    protected ActionLimiter actionLimiter;
    protected BanditData data;
    [SerializeField] private FacingCondition facingBy;
    protected Animator anim;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        facingComponent = animator.GetComponent<FacingComponent2D>();
        facingComponent.SetFacingBy(facingBy);
        rigidbody = animator.GetComponent<Rigidbody2D>();
        eventSystem = animator.GetComponent<BanditEventSystem>();
        banditPlayerDetector = animator.GetComponentInChildren<BanditPlayerDetector>();
        anim = animator;
        attackRangeDetector = animator.GetComponentInChildren<BanditAttackRangeDetector>();
        actionLimiter = animator.GetComponentInChildren<ActionLimiter>();
        data = animator.GetComponent<BanditData>();
    }

  

}
