using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class Heroine : MonoBehaviour
{
    private HeroineState state;
    private HeroineInput input;

    private Rigidbody2D rb;

    public float jumpForce = 7f;
    public float runSpeed = 5f;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float moveSpeedInair = 5f;
    
    public bool isFacingRight => transform.localScale.x > 0;



    [HideInInspector] public Animator animator;
    public Stack<HeroineState> states;

    // Component
    private CharacterFlipComponent flipComponent;

    private void Awake()
    {
        // set up reference
        states = new Stack<HeroineState>();
        animator = GetComponent<Animator>();
        state = gameObject.AddComponent<IdleState>();
        input = GetComponent<HeroineInput>();
        rb = GetComponent<Rigidbody2D>();
        
        
        // Set up component
        flipComponent = new CharacterFlipComponent(transform);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        UpdateStateMachine();
        
        flipComponent.Flip(input.horizontalMovement);

    }

    // Update is called once per frame
    void Update()
    {       
        HandleInput(input);
        
        
    }

    void UpdateStateMachine()
    {
        state.update(this, input);
    }

    public HeroineState RetrieveLastState()
    {
        return states.Pop();
    }

    public void HandleInput(HeroineInput input)
    {
        HeroineState newState = state.HandleInput(this,input);
        if (newState != null)
        {
            states.Push(state);
            state = newState;
            state.Enter(this);
            // print("entering state "+state.GetType().Name);
        }
    }
}

public class CharacterFlipComponent
{
    private Transform transform;
    private Rigidbody2D rb;
    public CharacterFlipComponent(Transform transform)
    {
        this.transform = transform;
        rb = transform.GetComponent<Rigidbody2D>();
    }
    
    public void Flip(float horizontalMovement)
    {
        Vector3 localScale = transform.localScale;

        if (rb.velocity.x < 0 && horizontalMovement < 0)
        {
            localScale.x = -1;
            transform.localScale = localScale;
        }
        else if (rb.velocity.x > 0 && horizontalMovement > 0)
        {
            localScale.x = 1;
            transform.localScale = localScale;

        }
    }
}