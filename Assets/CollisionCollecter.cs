using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCollecter : MonoBehaviour
{
    public List<Collider2D> detectedColliders;

    public DetectBy detectMethod;
    public string tagName;
    
    public event Action<Collider2D> onCollisionDetect;

    private void Awake()
    {
        detectedColliders = new List<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (detectMethod)
        {
            case DetectBy.Tag:
                if (other.CompareTag(tagName))
                {
                    detectedColliders.Add(other);
                    onCollisionDetect?.Invoke(other);
                }
                break;
            case DetectBy.Layer:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    
    
}

public enum DetectBy
{
    Tag, Layer
}
