using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private readonly float pickupOffsetX = 0.3f;
    private readonly float pickupOffsetY = 0.5f;
    protected float disappearTime = 0.5f; 
    public abstract void Pickup(PlayerCharacter player);
    
    protected void ChangeToPickupLocation(PlayerCharacter player)
    {
        
        transform.position = player.transform.position + new Vector3(player.isFacingRight?pickupOffsetX:-pickupOffsetX, pickupOffsetY);
    }
}