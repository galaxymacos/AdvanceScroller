using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicHeroMessagingSystem : MonoBehaviour
{
    public PsychicHeroInput heroInput;
    public Transform groundCheck;
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    
    public float movementSpeed = 5f;
    public bool canMove;
    [HideInInspector]public PsychicHeroHorizontalMovementComponent psychicHeroHorizontalMovementComponent;
    [HideInInspector] public CharacterFlipComponent flipComponent;
    

    private void Awake()
    {
        // set up variable
        heroInput = GetComponent<PsychicHeroInput>();
        
        
        psychicHeroHorizontalMovementComponent = new PsychicHeroHorizontalMovementComponent(movementSpeed, transform, heroInput);
        flipComponent = new CharacterFlipComponent(transform);
    }

    private void Update()
    {
        psychicHeroHorizontalMovementComponent.UpdateMovement();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        flipComponent.Flip(heroInput.horizontalMovement);
        
    }
}