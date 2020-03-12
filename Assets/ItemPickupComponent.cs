using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CollisionDetector))]
public class ItemPickupComponent : MonoBehaviour
{
    private CollisionDetector collisionDetector;
    public bool HasItemNearBy => GetItems().Count > 0;

    private void Awake()
    {
        collisionDetector = GetComponent<CollisionDetector>();
    }

    public bool PickUpRandomItem()
    {
        var listOfItems = GetItems();
        if (listOfItems.Count == 0)
        {
            return false;
        }
        var randomItem = listOfItems[Random.Range(0, listOfItems.Count)];
        randomItem.Pickup(GetComponentInParent<PlayerCharacter>());
        return true;
    }
    
    

    private List<Item> GetItems()
    {
        List<Item> items = new List<Item>();
        foreach (var objInCol in collisionDetector.ObjectsInCollision)
        {
            var item = objInCol.GetComponent<Item>();
            if (item != null)
            {
                items.Add(item);
            }
        }

        return items;
    }
}
