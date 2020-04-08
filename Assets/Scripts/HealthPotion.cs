using System;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private float recoveredAmount = 20f;

    public override void onBeingPickup(PlayerCharacter player)
    {
        var healthComponent = player.GetComponent<CharacterHealthComponent>();
        healthComponent.Heal(recoveredAmount);

    }

    

}