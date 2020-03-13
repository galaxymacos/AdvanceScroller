using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private readonly float pickupOffsetX = 0.3f;
    private readonly float pickupOffsetY = 0.5f;
    protected float disappearTime = 0.5f;
    protected bool hasBeenPickedUp;

    public void Pickup(PlayerCharacter player)
    {
        print("has picked up");
        hasBeenPickedUp = true;
        ChangeToPickupLocation(player);
        GetComponent<Rigidbody2D>().isKinematic = true;
        StartCoroutine(Consume(player));
    }

    private IEnumerator Consume(PlayerCharacter player)
    {
        yield return new WaitForSeconds(disappearTime);
        onBeingPickup(player);
        Destroy(gameObject);
    }


    public abstract void onBeingPickup(PlayerCharacter player);

    private void ChangeToPickupLocation(PlayerCharacter player)
    {
        transform.position = player.transform.position + new Vector3(player.isFacingRight?pickupOffsetX:-pickupOffsetX, pickupOffsetY);
    }
}