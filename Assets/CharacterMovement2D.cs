using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement2D : MonoBehaviour
{
    public PlayerInput playerInput;
    
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    
    private bool facingRight = true;
    
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;
    
    public int extraJumpsValue;
    private int extraJumps;
    private bool isJumping;
    private float jumpTimeCounter;
    public float jumpTime = 0.5f;
    public UnityEvent CharacterJumpEvent;
    public UnityEvent CharacterIdleEvent;
    public UnityEvent CharacterRunEvent;
    public UnityEvent CharacterDoubleJumpEvent;
    
    
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
    
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    
        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }
    
    private void Update()
    {
        Jump();
        
        if (isGrounded && Math.Abs(moveInput) < Mathf.Abs(Mathf.Epsilon) && !isJumping)
        {
            CharacterIdleEvent?.Invoke();
        }
        if (isGrounded && Math.Abs(moveInput) > Mathf.Epsilon && !isJumping)
        {
            CharacterRunEvent?.Invoke();
        }
    
    }
    
    /// <summary>
    /// Dealing with jump behavior
    /// </summary>
    private void Jump()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
    
        // jump 
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0 && !isGrounded)
        {
            isJumping = true;
            // rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            jumpTimeCounter = jumpTime;
            print("double jump");
    
            CharacterDoubleJumpEvent?.Invoke();
            
    
        }
        // jump 
        else if (playerInput.jump && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            print("jump");
            CharacterJumpEvent?.Invoke();
    
        }
    
        // jump 
        if (Input.GetKey(KeyCode.UpArrow) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }
    
        
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}