using System;
using System.Collections;
using UnityEngine;

public class GhostStats : MonoBehaviour
{
    
    public PlayerCharacter playerToChase;

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
    public int attackSucceedToCelebrate;
    public float lastAttackTime;
    public float attackCooldown = 1f;

    private void Awake()
    {
        interestPointInChasingCounter = maxInterestPointInChasing;
        distractIntervalInChasingCounter = maxDistractIntervalInChasing;
    }
}