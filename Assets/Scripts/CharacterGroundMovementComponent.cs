using UnityEngine;

/// <summary>
/// A component that control the entity's horizontal movement base on user input
/// </summary>
public class CharacterGroundMovementComponent: MovementComponent
{
    private float movementSpeed;
    private Rigidbody2D rb;
    private PlayerInput input;
    private bool canMove;
    private PlayerCharacter _playerCharacter;

    public CharacterGroundMovementComponent(float movementSpeed, Transform entity, PlayerInput input)
    {
        this.movementSpeed = movementSpeed;
        rb = entity.GetComponent<Rigidbody2D>();
        this.input = input;
        _playerCharacter = entity.GetComponent<PlayerCharacter>();
    }

    public override void UpdateMovement()
    {
        canMove = _playerCharacter.canControlMovement;
        if (canMove)
        {
            
            rb.velocity = new Vector2(movementSpeed * input.horizontalAxis, rb.velocity.y);
        }
        
    }
    
}