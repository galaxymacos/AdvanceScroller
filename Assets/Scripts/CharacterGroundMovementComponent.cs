using UnityEngine;

/// <summary>
/// A component that control the entity's horizontal movement base on user input
/// </summary>
public class CharacterGroundMovementComponent: MovementComponent
{
    private float movementSpeed;
    private Rigidbody2D rb;
    private PlayerInput input;
    private PlayerCharacter _playerCharacter;

    public CharacterGroundMovementComponent(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
        movementSpeed = playerCharacter.movementSpeed;
        rb = _playerCharacter.GetComponent<Rigidbody2D>();
        input = playerCharacter.playerInput;
    }

    public override void UpdateMovement()
    {
        if (_playerCharacter.canControlMovement)
        {
            
            rb.velocity = new Vector2(movementSpeed * input.horizontalAxis, rb.velocity.y);
        }
        
    }
    
}