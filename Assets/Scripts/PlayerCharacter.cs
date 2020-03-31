using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerInput playerInput;
    
    private float checkRadius = 0.03f;

    // Ground check
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    
    public bool isGrounded;

    [HideInInspector] public bool isGroundedOverride;
    [HideInInspector] public bool overrideGrounded;
    public bool IsGrounded => isGroundedOverride?overrideGrounded:isGrounded;

    public LayerMask whatIsGround;
    
    // Wall check
    public Transform wallLeftCheck;
    public Transform wallRightCheck;
    public bool isNextToWallLeft;
    public bool isNextToWallRight;
    public bool isTouchingLadderLeft;
    public bool isTouchingLadderRight;
    public LayerMask whatIsWall;
    public LayerMask whatIsLadder;
    public bool isOnLadderPosition;

    // ceiling check
    public Transform ceilingCheck;
    public bool isHitCeiling;
    
    
    [HideInInspector] public bool atEnemyLeft;
    [HideInInspector] public bool atEnemyRight;
    public LayerMask whatIsEnemy;

    [HideInInspector] public int jumpTime;
    [HideInInspector] public int maxJumpTime = 2;
    
    
    public int maxDashTimeInAir = 1;
    public int dashTimeCounter;
    public bool isDead=>characterHealthComponent.isPlayerDead;
    public float dashInvincibleTime = 0.3f;
    public float dashInvincibleTimeCounter;
    
    
    public List<Collider2D> collidersAlive;
    public List<Collider2D> collidersDead;
    
    public SingleAttackComponent impactWave;

    public event Action onFacingDirectionChanged;
    public Action onPlayerStartMove;
    public Action onPlayerStartDoubleJump;
    public Action onPlayerStartJump;
    public Action onPlayerGrounded;
    public Action onPlayerStartDash;
    public Action onPlayerDodgeSucceed;
    public Action onPlayerWalkNextToWall;
    public Action onPlayerExitWall;
    public Action onPlayerExitLadder;
    public Action onUniqueSkillStart;
    public Action onUniqueSkillEnd;
    public Action onCatchingSuccess;
    public Action onPlayerHitCeiling;
    public Action onPlayerUseUltimate;
    public Action onPlayerBeingPushed;
    public Action onPlayerBeingHurted;
    public Action onPlayerBeingStunned;
    
    // Call this when the player successfully dash out from the hurt state
    public Action onDashOutFromHurt;
    
    // Animation event
    public Action onPlayerStartWallSlide;
    public Action onPlayerStopWallSlide;

    private Rigidbody2D rb;
    public bool isFacingRight => transform.localScale.x > 0;
    
    public float MovementSpeed => IsMoveSpeedOverriden? OverridenMovementSpeed : MovementSpeedOriginal;
    public float MovementSpeedOriginal = 5f;
    public bool IsMoveSpeedOverriden;
    public float OverridenMovementSpeed;
    
    public bool canControlMovement;
    [HideInInspector]public CharacterGroundMovementComponent characterGroundMovementComponent;
    [HideInInspector] public CharacterFlipComponent flipByInputComponent;
    [HideInInspector] public GameObject chargedDagger;

    public Sprite winPose;
    private CharacterHealthComponent characterHealthComponent;

    private void Awake()
    {
        // set up variable
        playerInput = GetComponent<PlayerInput>();
        
        characterGroundMovementComponent = new CharacterGroundMovementComponent(this);
        flipByInputComponent = new CharacterFlipComponent(transform);
        characterHealthComponent = GetComponent<CharacterHealthComponent>();
        onPlayerGrounded += ResetJumpTime;

        rb = GetComponent<Rigidbody2D>();


    }
    

    private void Update()
    {
        UpdateFacingDirection();

        if (dashInvincibleTimeCounter > 0)
        {
            dashInvincibleTimeCounter -= Time.deltaTime;
        }

    }
    private void FixedUpdate()
    {
        UpdatePlayerMovementVariable();
    }

    private void UpdateFacingDirection()
    {
        var wasFacingRight = isFacingRight;
        
        // Filp by input
        if (playerInput != null && canControlMovement)
        {
            flipByInputComponent.Flip(playerInput.horizontalAxis);
        }
        
        if (isFacingRight != wasFacingRight)
        {
            onFacingDirectionChanged?.Invoke();
        }
    }


    private void UpdateMovement()
    {
        float horizontalVelocityBefore = GetComponent<Rigidbody2D>().velocity.x;
        float previousXLocation = transform.position.x;
        characterGroundMovementComponent.UpdateMovement();
        float horizontalVelocityAfter = GetComponent<Rigidbody2D>().velocity.x;
        float afterXLocation = transform.position.x;

        if (Math.Abs(horizontalVelocityBefore) < Mathf.Epsilon && horizontalVelocityAfter > Mathf.Epsilon && isFacingRight)
        {
            if (Mathf.Abs(afterXLocation - previousXLocation) > Mathf.Epsilon)
            {
                onPlayerStartMove?.Invoke();
            }
        }
        else if (Math.Abs(horizontalVelocityBefore) < Mathf.Epsilon && horizontalVelocityAfter < -Mathf.Epsilon &&
                 !isFacingRight)
        {
            if (Mathf.Abs(afterXLocation - previousXLocation) > Mathf.Epsilon)
            {
                onPlayerStartMove?.Invoke();
            }
        }
    }

    

    private void UpdatePlayerMovementVariable()
    {
        UpdateMovement();

        bool wasGrounded = isGrounded;
        bool isGroundedLeft = Physics2D.OverlapCircle(groundCheckLeft.position, checkRadius, whatIsGround);
        bool isGroundedRight = Physics2D.OverlapCircle(groundCheckRight.position, checkRadius, whatIsGround);
        isGrounded = isGroundedLeft || isGroundedRight;
        if (wasGrounded != isGrounded && isGrounded)
        {
            onPlayerGrounded?.Invoke();

        }

        bool wasHitCeiling = isHitCeiling;
        isHitCeiling = Physics2D.OverlapCircle(ceilingCheck.position, checkRadius, whatIsGround);
        if (wasHitCeiling != isHitCeiling && isHitCeiling)
        {
            onPlayerHitCeiling?.Invoke();
        }
        

        bool wasNextToWallRight = isNextToWallRight;
        isNextToWallRight = Physics2D.OverlapCircle(wallRightCheck.position, checkRadius, whatIsWall);
        if (wasNextToWallRight != isNextToWallRight && isNextToWallRight && isFacingRight)
        {
            onPlayerWalkNextToWall?.Invoke();
        }
        else if (wasNextToWallRight != isNextToWallRight && !isNextToWallRight && isFacingRight)
        {
            onPlayerExitWall?.Invoke();
        }
        
        bool wasNextToWallLeft = isNextToWallLeft;
        isNextToWallLeft = Physics2D.OverlapCircle(wallLeftCheck.position, checkRadius, whatIsWall);
        if (wasNextToWallLeft != isNextToWallLeft && isNextToWallLeft && !isFacingRight)
        {
            onPlayerWalkNextToWall?.Invoke();
        }
        else if(wasNextToWallLeft != isNextToWallLeft && !isNextToWallLeft && !isFacingRight)
        {
            onPlayerExitWall?.Invoke();
        }
        
        bool wasTouchingLadderLeft = isTouchingLadderLeft;
        bool wasTouchingLadderRight = isTouchingLadderRight;
        isTouchingLadderRight = Physics2D.OverlapCircle(wallRightCheck.position, checkRadius, whatIsLadder);
        isTouchingLadderLeft = Physics2D.OverlapCircle(wallLeftCheck.position, checkRadius, whatIsLadder);
        if (isTouchingLadderLeft && isTouchingLadderRight)
        {
            isOnLadderPosition = true;
        }
        else
        {
            isOnLadderPosition = false;
        }

        if ((isTouchingLadderLeft && isTouchingLadderRight) == false && wasTouchingLadderLeft && wasTouchingLadderRight)
        {
            onPlayerExitLadder?.Invoke();
        }
        
        atEnemyRight = Physics2D.OverlapCircle(wallLeftCheck.position, 0.2f, whatIsEnemy);
        atEnemyLeft = Physics2D.OverlapCircle(wallRightCheck.position, 0.2f, whatIsEnemy);
    }

    private void ResetJumpTime()
    {
        jumpTime = 0;
        dashTimeCounter = 0;
    }

    public void SpawnImpactWave()
    {
        impactWave.Execute();
    }
    
}

