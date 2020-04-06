using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionCollecter : MonoBehaviour
{
    public List<Collider2D> detectedColliders;

    public DetectBy detectMethod;
    public string tagName;
    public LayerMask layerToCollide;
    
    public event Action<Collider2D> onCollisionDetect;
    public UnityEvent onCollisionDetectUnityEvent;

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
                    onCollisionDetectUnityEvent?.Invoke();
                }
                break;
            case DetectBy.Layer:
                if ((1<<other.gameObject.layer & layerToCollide)!=0)
                {
                    detectedColliders.Add(other);
                    onCollisionDetect?.Invoke(other);
                    onCollisionDetectUnityEvent?.Invoke();
                }
                break;
            case DetectBy.Everything:
                detectedColliders.Add(other);
                onCollisionDetect?.Invoke(other);
                onCollisionDetectUnityEvent?.Invoke();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    
    
}

public enum DetectBy
{
    Tag, Layer, Everything
}
