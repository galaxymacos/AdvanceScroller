using System;
using UnityEngine;

public class UnknownPotion : Item
{
    public Action<UnknownPotion> onPickup;
    public override void Pickup(PlayerCharacter player)
    {
        onPickup?.Invoke(this);
        
        GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(gameObject, disappearTime);
    }
    
    
}