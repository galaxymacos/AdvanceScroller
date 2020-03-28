using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Have a list of the object which is in the collision
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class CollisionDetector: MonoBehaviour
{
    public List<GameObject> ObjectsInCollision => objectsInCollision;
    public Action<GameObject> onObjectCollided;

    
    private List<GameObject> objectsInCollision;
    

    private void OnDisable()
    {
        objectsInCollision = new List<GameObject>();
    }

    private void OnEnable()
    {
        objectsInCollision = new List<GameObject>();
        
    }

    private void Update()
    {
        for (int i = 0; i < objectsInCollision.Count; i++)
        {
            if (objectsInCollision[i] == null)
            {
                ObjectsInCollision.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectsInCollision == null)
        {
            objectsInCollision = new List<GameObject>();
        }

        if (!objectsInCollision.Contains(other.transform.gameObject) && other.transform.GetComponent<IDamageReceiver>()!=null)
        {
            objectsInCollision.Add(other.transform.gameObject);
            onObjectCollided?.Invoke(other.transform.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (objectsInCollision != null)
        {
            if (objectsInCollision.Contains(other.transform.root.gameObject) && other.transform.GetComponent<IDamageReceiver>()!=null)
            {
                objectsInCollision.Remove(other.transform.root.gameObject);
            }
        }
    }
}
