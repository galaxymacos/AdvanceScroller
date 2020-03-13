using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private float recoveredAmount = 20f;
    public override void Pickup(PlayerCharacter player)
    {
        var healthComponent = player.GetComponent<CharacterHealthComponent>();
        healthComponent.Heal(recoveredAmount);
        
        ChangeToPickupLocation(player);
        GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(gameObject, disappearTime);
        
    }

    

}

public class ThunderPotion : Item
{
    public override void Pickup(PlayerCharacter player)
    {
        
    }
}