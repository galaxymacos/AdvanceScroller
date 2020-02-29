using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterPauser : MonoBehaviour, IPauseable
{
    private Rigidbody2D rb;
    private PlayerCharacter playerCharacter;
    private bool isPausing;
    private Vector3 velocityBeforePause;
    
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCharacter = GetComponent<PlayerCharacter>();
        animator = GetComponent<Animator>();
    }

    public void Pause()
    {
        if (isPausing)
        {
            print("game object is already pausing");
            return;
        }
        
        animator.speed = 0f;
        velocityBeforePause = rb.velocity;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        isPausing = true;
    }

    public void UnPause()
    {
        if (!isPausing)
        {
            print("object is not pausing, but trying to pause");
            return;
        }
        
        animator.speed = 1f;
        rb.isKinematic = false;
        rb.velocity = velocityBeforePause;

        isPausing = false;
    }
}
