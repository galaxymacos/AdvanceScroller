using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionDetector))]
public class CatchComponent : MonoBehaviour
{
    
    private PlayerCharacter playerCaught;
    public PlayerCharacter PlayerCaught => playerCaught;

    private CollisionDetector collisionDetector;
    private bool isActivated;
    private PlayerCharacter owner;

    private void Awake()
    {
        owner = transform.root.GetComponent<PlayerCharacter>();
        collisionDetector = GetComponent<CollisionDetector>();
        collisionDetector.onObjectCollided += TryCatch;
    }

    private void TryCatch(GameObject obj)
    {
        PlayerCharacter target = obj.GetComponent<PlayerCharacter>();
        
        if (target != null)
        {
            playerCaught = target;
            owner.onCatchingSuccess?.Invoke();
        }
    }

    public void Activate()
    {
        isActivated = true;
        collisionDetector.enabled = true;
    }

    public void DeActivate()
    {
        collisionDetector.enabled = false;
        isActivated = false;
    }
    
}
