using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterPauser : MonoBehaviour, IPauseable
{

    public Action onCharacterPaused;
    public Action onCharacterResumed;


    private Rigidbody2D rb;
    private PlayerCharacter playerCharacter;
    private bool isPausing;

    public bool IsPausing => isPausing;

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
            return;
        }

        velocityBeforePause = rb.velocity;
        animator.speed = 0f;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        isPausing = true;
        
        if (playerCharacter.playerInput != null)
        {
            playerCharacter.playerInput.acceptInput = false;
        }
        
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
        
        if (playerCharacter.playerInput != null)
        {
            playerCharacter.playerInput.acceptInput = true;
        }

        onCharacterResumed?.Invoke();

    }
}
