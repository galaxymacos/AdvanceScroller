using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SMB_Ghost_Wander : GhostStateMachineBehavior
{
    [SerializeField] private float idleTime = 2f;

    private bool isIdling => stateIndex == 0;
    private bool isWandering => stateIndex == 1;
    // 0 is idle, 1 is wander
    private int stateIndex;
    private float idleTimeCounter;
    [SerializeField] private float moveSpeed = 5f;
    public float detectPlayerRange;
    private Vector3 randomPointInMap;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        idleTimeCounter = idleTime;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        transform = animator.GetComponent<Transform>();
        anim = animator;
        stateIndex = 0;
        ghostFacingComponent.SetFacingDelegate(GhostFacingComponent.FacingCondition.FaceByVelocity);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isIdling)
        {
            rigidbody.velocity = Vector2.zero;
            if (idleTimeCounter>0)
            {
                idleTimeCounter -= Time.deltaTime;
                if (idleTimeCounter <= 0)
                {
                    stateIndex = 1;
                    GetRandomWanderingPoint();
                }
            }
        }
        else if (isWandering)
        {
            DetectPlayer();
            StopIfNearDestination();
        }
        
        
        
    }

    private void StopIfNearDestination()
    {
        if (Vector3.Distance(transform.position, randomPointInMap) < 3)
        {
            idleTimeCounter = idleTime;
            stateIndex = 0;
        }
    }

    private void DetectPlayer()
    {
        Collider2D[] players =new Collider2D[20];
        var numberOfCollider = Physics2D.OverlapCircleNonAlloc(transform.position, detectPlayerRange, players, LayerInfo.WhatIsPlayer);
        if (numberOfCollider > 0)
        {
            Debug.Log("playing is found");
            var randomPlayer = players[Random.Range(0, numberOfCollider)].gameObject.GetComponent<PlayerCharacter>();
            if (randomPlayer != null)
            {
                transform.GetComponent<GhostStats>().playerToChase = randomPlayer;
                anim.SetTrigger(ghostScoreSystem.GetNextAction());
            }
        }
    }

    public void GetRandomWanderingPoint()
    {
        randomPointInMap = MapInfo.instance.Inquirer.RandomPointInMap();
        rigidbody.velocity = Vector3.Normalize(randomPointInMap - transform.position) * moveSpeed;
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
