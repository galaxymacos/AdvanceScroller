using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// [RequireComponent(typeof(CollisionDetector))]
public class ItemPickupComponent : MonoBehaviour
{
    // private CollisionDetector collisionDetector;
    public bool HasItemNearBy => items.Count > 0;



    public List<Item> items;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Item>() != null)
        {
            items.Add(other.GetComponent<Item>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Item>() != null)
        {
            items.Remove(other.GetComponent<Item>());
        }
    }

    public bool PickUpRandomItem()
    {
        print("try pick up random items");
        if (items.Count == 0)
        {
            return false;
        }

        Item randomItem = items[Random.Range(0, items.Count)];
        if (!randomItem.canBePickedUp) return false;

        items.Remove(items[Random.Range(0, items.Count)]);
        randomItem.Pickup(GetComponentInParent<PlayerCharacter>());
        return true;
    }
    
    

  
}
