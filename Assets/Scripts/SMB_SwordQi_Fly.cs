using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_SwordQi_Fly : StateMachineBehaviour
{
    private Animator anim;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim = animator;
        anim.GetComponent<CollisionCollecter>().onCollisionDetect += ToBreakState;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim.GetComponent<CollisionCollecter>().onCollisionDetect -= ToBreakState;
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

    private void ToBreakState(Collider2D collider2D)
    {
        if (anim.GetComponent<NewProjectile>().owner!=null && collider2D.gameObject != anim.GetComponent<NewProjectile>().owner)
        {
            Debug.Log("collide with "+collider2D.gameObject.name);
            anim.SetTrigger("break");
        }
    }
}
