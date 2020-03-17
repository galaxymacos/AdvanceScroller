using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_Cat_Explode : CatStateMachineBahavior
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        Destroy(animator.gameObject);
    }
    
}
