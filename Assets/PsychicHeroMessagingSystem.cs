using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicHeroMessagingSystem : MonoBehaviour
{
    public PlayerTwoInput heroInput;
    public Transform groundCheck;
    public bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    public GameObject knifePrefab;
    public Transform spawnTransform;
    public bool hasDoubleJump = false;
    
    public bool isFacingRight => transform.localScale.x > 0;

    
    
    public float movementSpeed = 5f;
    public bool canMove;
    [HideInInspector]public PsychicHeroHorizontalMovementComponent psychicHeroHorizontalMovementComponent;
    [HideInInspector] public CharacterFlipComponent flipComponent;
    

    private void Awake()
    {
        // set up variable
        heroInput = GetComponent<PlayerTwoInput>();
        
        
        psychicHeroHorizontalMovementComponent = new PsychicHeroHorizontalMovementComponent(movementSpeed, transform, heroInput);
        flipComponent = new CharacterFlipComponent(transform);
        spawnTransform = transform.Find("SpawnLocations").Find("Sword");

    }

    private void Update()
    {
        psychicHeroHorizontalMovementComponent.UpdateMovement();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            hasDoubleJump = false;
        }
        flipComponent.Flip(heroInput.horizontalAxis);
        
    }
    
    public void SpawnKnife()
    {
        GameObject knife = Instantiate(knifePrefab, spawnTransform.position, transform.rotation);
        knife.GetComponent<Sword>().moveRight = isFacingRight;
    }
}