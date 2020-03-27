using System;
using UnityEngine;

public class GhostStateMachineBehavior : StateMachineBehaviour
{
    protected Transform transform;
    protected Rigidbody2D rigidbody;
    protected GhostStats ghostStats;
    protected GhostFacingComponent ghostFacingComponent;
    protected GhostScoreSystem ghostScoreSystem;
    protected GhostEventSystem ghostEventSystem;


    protected Animator anim;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim = animator;
        ghostStats = animator.GetComponent<GhostStats>();
        transform = animator.transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        ghostFacingComponent = animator.GetComponent<GhostFacingComponent>();
        ghostScoreSystem = animator.GetComponent<GhostScoreSystem>();
        ghostEventSystem = animator.GetComponent<GhostEventSystem>();
        ghostEventSystem.onGhostDie += PlayDieAnimation;
        ghostStats.lastAnimationState = animator.GetCurrentAnimatorStateInfo(0);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        ghostEventSystem.onGhostDie -= PlayDieAnimation;
    }


    public void PlayDieAnimation()
    {
        anim.SetTrigger("die");
    }
}