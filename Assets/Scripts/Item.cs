using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private readonly float pickupOffsetX = 0.3f;
    private readonly float pickupOffsetY = 0.5f;
    [SerializeField] protected Sprite itemSprite;
    protected float disappearTime = 0.5f;
    protected bool hasBeenPickedUp;
    private PlayerCharacter holder;

    public void Pickup(PlayerCharacter player)
    {
        hasBeenPickedUp = true;
        
        holder = player;
        ChangeToPickupLocation(player);
        GetComponent<Rigidbody2D>().isKinematic = true;

        player.onPlayerBeingHurted += Drop;
        player.onPlayerBeingPushed += Drop;
        player.onPlayerBeingStunned += Drop;
        
        StartCoroutine(Consume(player));
    }

    private void Drop()
    {
        hasBeenPickedUp = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
        StopAllCoroutines();
    }

    private IEnumerator Consume(PlayerCharacter player)
    {
        yield return new WaitForSeconds(disappearTime);
        onBeingPickup(player);
        player.onPlayerBeingHurted += Drop;
        player.onPlayerBeingPushed += Drop;
        player.onPlayerBeingStunned += Drop;
        Destroy(gameObject);
    }
    
    


    public abstract void onBeingPickup(PlayerCharacter player);

    private void ChangeToPickupLocation(PlayerCharacter player)
    {
        transform.position = player.transform.position + new Vector3(player.isFacingRight?pickupOffsetX:-pickupOffsetX, pickupOffsetY);
    }
}