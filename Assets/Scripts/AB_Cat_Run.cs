using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_Cat_Run : CatStateMachineBahavior
{
    [SerializeField] private float runSpeed = 4f;


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        Debug.Log("run");
        var velocity = rb.velocity;
        velocity = cat.isFacingRight ? new Vector2(runSpeed, velocity.y) : new Vector2(-runSpeed, velocity.y);
        rb.velocity = velocity;

        if (cat.IsGrounded())
        { 
            if (cat.IsNearEdge())
            {
                animator.SetTrigger("jump");
            }
        }
    }

   
}