using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerInput playerInput;
    public Transform groundCheck;
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool hasDoubleJump;
    

    
    public bool isFacingRight => transform.localScale.x > 0;

    
    
    public float movementSpeed = 5f;
    public bool canMove;
    [HideInInspector]public CharacterGroundMovementComponent characterGroundMovementComponent;
    [HideInInspector] public CharacterFlipComponent flipComponent;
    

    private void Awake()
    {
        // set up variable
        playerInput = GetComponent<PlayerInput>();
        
        
        characterGroundMovementComponent = new CharacterGroundMovementComponent(movementSpeed, transform, playerInput);
        flipComponent = new CharacterFlipComponent(transform);
        // spawnTransform = transform.Find("SpawnLocations").Find("Sword");

    }

    private void Update()
    {
        characterGroundMovementComponent.UpdateMovement();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            hasDoubleJump = false;
        }
        flipComponent.Flip(playerInput.horizontalAxis);
        
    }
    
   
}

