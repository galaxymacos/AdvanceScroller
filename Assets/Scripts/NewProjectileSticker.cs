using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(NewProjectile))]

public class NewProjectileSticker : MonoBehaviour
{
    
    private NewProjectile newProjectile;
    [SerializeField] private float stickDelay = 0.03f;
    private float stickDelayCounter;
    private GameObject owner;
    public LayerMask layerToStick;
    
    private GameObject objectToStickTo;

    public UnityEvent onStickToObject;

    private void Awake()
    {
        newProjectile = GetComponent<NewProjectile>();
        newProjectile.onProjectileSetupFinished += Setup;
    }

    private void Setup(NewProjectile.ProjectileArgument obj)
    {
        owner = obj.owner;
    }


    // Update is called once per frame
    void Update()
    {
        if (stickDelayCounter > 0)
        {
            stickDelayCounter -= Time.deltaTime;
            if (stickDelayCounter <= 0)
            {
                StickToObject();
            }
        }
    }

    public void StickToObject()
    {
        print("stick to object");
        
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
        
        transform.parent = objectToStickTo.transform;
        
        onStickToObject?.Invoke();

    }

    private void ReadyToStick()
    {
        print("Ready to stick");
        stickDelayCounter = stickDelay;
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root.gameObject != owner.gameObject && (1<<other.gameObject.layer & layerToStick)!=0)
        {
            ReadyToStick();
            objectToStickTo = other.gameObject;
        }
    }
}
