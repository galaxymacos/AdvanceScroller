using System;
using System.Collections;
using UnityEngine;

public class GhostStats : MonoBehaviour
{
    
    public PlayerCharacter playerToChase;
    public AnimatorStateInfo lastAnimationState;

    // data
    public float health = 250f;
    public float chaseSpeed = 5f;
    public float moveSpeed = 6f;
    public float attackRange = 5f;
    public float detectPlayerRange = 20f;

    // Wander Value
    public float idleTime = 3f;

    // Chasing Value
    public float rangeToLoseInterestInChasing = 15;
    public float maxDistractIntervalInChasing = 4f;
    public float distractIntervalInChasingCounter;

    public float maxInterestPointInChasing = 100;
    public float interestPointToLoseInChasingPerSec = 2;
    public float interestPointInChasingCounter = 0;
    

    // Attack Value
    public int scoreToCelebratePerAttack = 50;
    public int attackSucceedNum;
    public float lastAttackTime;
    public float lastHitTime;
    public float attackCooldown = 1f;
    public float attackDashSpeed = 10f;

    private void Awake()
    {
        interestPointInChasingCounter = maxInterestPointInChasing;
        distractIntervalInChasingCounter = maxDistractIntervalInChasing;
    }
}