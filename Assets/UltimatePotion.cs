using UnityEngine;

public class UltimatePotion : Item
{
    [SerializeField] private float amount = 20f;

    public override void onBeingPickup(PlayerCharacter player)
    {
        RageComponent ultimateComponent = player.GetComponent<RageComponent>();
        ultimateComponent.RecoverRage(amount);
    }
}