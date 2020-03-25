using UnityEngine;

/// <summary>
/// A component that control the entity's horizontal movement base on user input
/// </summary>
public class CharacterGroundMovementComponent: MovementComponent
{
    private readonly Rigidbody2D rb;
    private readonly PlayerCharacter _playerCharacter;

    public CharacterGroundMovementComponent(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
        rb = _playerCharacter.GetComponent<Rigidbody2D>();
    }

    public override void UpdateMovement()
    {

        if (_playerCharacter.canControlMovement && _playerCharacter.playerInput!=null && !_playerCharacter.GetComponent<CharacterPauser>().IsPausing)
        {
            rb.velocity = new Vector2(_playerCharacter.MovementSpeed * _playerCharacter.playerInput.horizontalAxis, rb.velocity.y);
        }
        
    }
    
}