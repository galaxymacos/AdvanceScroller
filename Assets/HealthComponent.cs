using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int health = 100;

    private Animator animator;
    private static readonly int Die = Animator.StringToHash("die");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void TakeDamage(int amount)
    {
        health = Mathf.Clamp(health-amount, 0, 100);
        if (health == 0)
        {
            animator.SetTrigger(Die);
        }
    }
    
    public void Heal(int amount)
    {
        health = Mathf.Clamp(health+amount, 0, 100);
    }

    
}
