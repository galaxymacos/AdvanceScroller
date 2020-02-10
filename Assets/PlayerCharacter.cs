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
    public int maxDashTimeInAir = 1;
    public int dashTimeCounter;
    public List<Collider2D> collidersAlive;
    public List<Collider2D> collidersDead;
    public GameObject runParticle;
    public GameObject groundDustTwoWays;

    public Action facingDirectionChanged;
    

    
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
        facingDirectionChanged += SpawnGroundDust;
        // spawnTransform = transform.Find("SpawnLocations").Find("Sword");

    }

    private void Update()
    {
        float horizontalVelocityBefore = GetComponent<Rigidbody2D>().velocity.x;
        characterGroundMovementComponent.UpdateMovement();
        float horizontalVelocityAfter = GetComponent<Rigidbody2D>().velocity.x;
        if (Math.Abs(horizontalVelocityBefore) < Mathf.Epsilon && horizontalVelocityAfter > Mathf.Epsilon && isFacingRight)
        {
            SpawnGroundDust();
        }
        else if (Math.Abs(horizontalVelocityBefore) < Mathf.Epsilon && horizontalVelocityAfter < -Mathf.Epsilon && !isFacingRight)
        {
            SpawnGroundDust();
        }

            var wasFacingRight = isFacingRight;
        flipComponent.Flip(playerInput.horizontalAxis);
        if (isFacingRight != wasFacingRight)
        {
            facingDirectionChanged?.Invoke();
            
        }
    }

    public void SpawnGroundDust()
    {
        if (!isGrounded)
        {
            return;
        }
        var groundDust = Instantiate(runParticle, transform.Find("SpawnLocations").Find("GroundDust").position,
            transform.rotation);
        groundDust.GetComponent<ParticleFacingComponent>().Setup(this);
    }
    
    public void SpawnGroundDustTwoWays()
    {
        if (groundDustTwoWays != null)
        {
            var groundDust = Instantiate(groundDustTwoWays, transform.Find("SpawnLocations").Find("GroundDustTwoWays").position,
                transform.rotation);
            groundDust.GetComponent<ParticleFacingComponent>().Setup(this);
        }
        
        
    }

    private void FixedUpdate()
    {
        updateGrounded();
    }

    private void updateGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (wasGrounded != isGrounded && isGrounded)
        {
            SpawnGroundDustTwoWays();

        }
        if (isGrounded)
        {
            hasDoubleJump = false;
            dashTimeCounter = 0;
        }
    }
}

