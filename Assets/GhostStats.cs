using System.Collections;
using UnityEngine;

public class GhostStats : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter playerToChase;
    
    public float chaseSpeed = 5f;
    public float moveSpeed = 6f;
    public float attackRange = 5f;
    public float detectPlayerRange = 20f;


}