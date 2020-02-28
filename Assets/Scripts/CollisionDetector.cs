using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Have a list of the object which is in the collision
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class CollisionDetector: MonoBehaviour
{
    protected List<GameObject> objectsInCollision;
    public Action<GameObject> onObjectCollided;

    public void ResetCollision()
    {
        objectsInCollision = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectsInCollision == null)
        {
            objectsInCollision = new List<GameObject>();
        }

        if (!objectsInCollision.Contains(other.gameObject))
        {
            objectsInCollision.Add(other.gameObject);
            onObjectCollided?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (objectsInCollision != null)
        {
            if (objectsInCollision.Contains(other.gameObject))
            {
                objectsInCollision.Remove(other.gameObject);
            }
        }
    }
}