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
    
    [Header("Particle")]
    public GameObject groundDust;
    public GameObject deadParticle;
    public GameObject groundDustTwoWays;
    [Space(10)]

    public Action onFacingDirectionChanged;
    public Action onPlayerStartMove;
    public Action onPlayerStartDoubleJump;
    public Action onPlayerStartJump;
    public Action onPlayerGrounded;
    public Action onPlayerStartDash;
    

    
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
        float horizontalVelocityBefore = GetComponent<Rigidbody2D>().velocity.x;
        characterGroundMovementComponent.UpdateMovement();
        float horizontalVelocityAfter = GetComponent<Rigidbody2D>().velocity.x;
        if (Math.Abs(horizontalVelocityBefore) < Mathf.Epsilon && horizontalVelocityAfter > Mathf.Epsilon && isFacingRight)
        {
            onPlayerStartMove?.Invoke();
        }
        else if (Math.Abs(horizontalVelocityBefore) < Mathf.Epsilon && horizontalVelocityAfter < -Mathf.Epsilon && !isFacingRight)
        {
            onPlayerStartMove?.Invoke();
        }

        var wasFacingRight = isFacingRight;
        flipComponent.Flip(playerInput.horizontalAxis);
        if (isFacingRight != wasFacingRight)
        {
            onFacingDirectionChanged?.Invoke();
            
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
            onPlayerGrounded?.Invoke();

        }
        if (isGrounded)
        {
            hasDoubleJump = false;
            dashTimeCounter = 0;
        }
    }

}

