using System;
using UnityEngine;

public class EnemyPauser: MonoBehaviour, IPauseable
{
    public Action onCharacterPaused;
    public Action onCharacterResumed;


    private Rigidbody2D rb;
    private bool isPausing;

    public bool IsPausing => isPausing;

    private Vector3 velocityBeforePause;
    
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void Pause()
    {
        if (isPausing)
        {
            return;
        }

        velocityBeforePause = rb.velocity;
        animator.speed = 0f;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        isPausing = true;
        
        onCharacterPaused?.Invoke();
    }

    public void UnPause()
    {
        if (!isPausing)    
        {
            return;
        }
        
        animator.speed = 1f;
        rb.isKinematic = false;
        rb.velocity = velocityBeforePause;
        isPausing = false;
        

        onCharacterResumed?.Invoke();

    }

}