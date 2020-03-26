using System.Collections;
using UnityEngine;

public class GhostStats : MonoBehaviour
{
    
    public PlayerCharacter playerToChase;

    public float health = 250f;
    public float chaseSpeed = 5f;
    public float moveSpeed = 6f;
    public float attackRange = 5f;
    public float detectPlayerRange = 20f;
    public float lastAttackTime;
    public float wanderDistractInterval = 4f;
    public float idleTime = 3f;
    public float attackCooldown = 1f;
    public int attackSucceedToCelebrate;
    
    
}