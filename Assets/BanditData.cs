using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditData : MonoBehaviour
{
    public float lastAttackTime;

    public float attackCooldown = 3f;
    public float timePassMultiplierWhenPlayerInRange = 3;
    public float alertTime = 6f;
    public float alertTimeCounter;
    public Transform[] jumpingPoints;
    public int maxJumpingTime;
    public int jumpingTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alertTimeCounter > 0)
        {
            alertTimeCounter -= Time.deltaTime;
        }
    }
}
