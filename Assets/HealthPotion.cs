using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private float recoveredAmount = 20f;
    public override void Pickup(PlayerCharacter player)
    {
        print("item is picked up");
        var healthComponent = player.GetComponent<CharacterHealthComponent>();
        healthComponent.Heal(recoveredAmount);
    }

}