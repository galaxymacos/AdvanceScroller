using UnityEngine;

/// <summary>
/// A component that control the entity's horizontal movement base on user input
/// </summary>
public class CharacterGroundMovementComponent: MovementComponent
{
    private float movementSpeed;
    private Rigidbody2D rb;
    private PlayerCharacter _playerCharacter;

    public CharacterGroundMovementComponent(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
        movementSpeed = playerCharacter.MovementSpeed;
        rb = _playerCharacter.GetComponent<Rigidbody2D>();
    }

    public override void UpdateMovement()
    {
        if (_playerCharacter.canControlMovement && _playerCharacter.playerInput!=null && !_playerCharacter.GetComponent<CharacterPauser>().IsPausing)
        {
            rb.velocity = new Vector2(movementSpeed * _playerCharacter.playerInput.horizontalAxis, rb.velocity.y);
        }
        
    }
    
}