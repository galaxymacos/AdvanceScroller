using UnityEngine;

/// <summary>
/// A component that control the entity's horizontal movement base on user input
/// </summary>
public class PsychicHeroHorizontalMovementComponent: MovementComponent
{
    private float movementSpeed;
    private Rigidbody2D rb;
    private PlayerTwoInput input;
    private bool canMove;
    private PsychicHeroMessagingSystem psychicHeroMessagingSystem;

    public PsychicHeroHorizontalMovementComponent(float movementSpeed, Transform entity, PlayerTwoInput input)
    {
        this.movementSpeed = movementSpeed;
        rb = entity.GetComponent<Rigidbody2D>();
        this.input = input;
        psychicHeroMessagingSystem = entity.GetComponent<PsychicHeroMessagingSystem>();
    }

    public override void UpdateMovement()
    {
        canMove = psychicHeroMessagingSystem.canMove;
        if (canMove)
        {
            
            rb.velocity = new Vector2(movementSpeed * input.horizontalAxis, rb.velocity.y);
        }
        
    }
    
}