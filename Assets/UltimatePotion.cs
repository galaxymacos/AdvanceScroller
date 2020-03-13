using UnityEngine;

public class UltimatePotion : Item
{
    [SerializeField] private float amount = 20f;

    public override void Pickup(PlayerCharacter player)
    {
        RageComponent ultimateComponent = player.GetComponent<RageComponent>();
        ultimateComponent.RecoverRage(amount);
        
        ChangeToPickupLocation(player);
        GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(gameObject, disappearTime);
    }
}