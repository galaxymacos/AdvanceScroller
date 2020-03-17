using System;
using UnityEngine;

public class CatStateMachineBahavior : StateMachineBehaviour
{
    protected Cat cat;

    protected Rigidbody2D rb;
    protected Animator anim;
    private static bool hasSetupEvent;
    // private void Awake()
    // {
    //     if (!hasSetupEvent)
    //     {
    //         hasSetupEvent = true;
    //     }
    //
    // }
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cat = animator.GetComponent<Cat>();
        rb = animator.GetComponent<Rigidbody2D>();
        anim = animator;
        cat.OnHitPlayer += CatExplode;

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (cat.IsNearWall())
        {
            CatExplode();
        }
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        cat.OnHitPlayer -= CatExplode;
    }

    private void CatExplode()
    {
        anim.SetTrigger("explosion");
    }
}