using System;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttackComponent : CollisionDetector, IAttackComponent
{
    private bool hasDealDamaged;
    private bool isRunning;
    public DamageData damageData;

    public List<GameObject> objectsHasProcessed = new List<GameObject>();

    private void Update()
    {
        if (!isRunning) return;
        if (ObjectsInCollision == null) return;
        
        
        foreach (GameObject objectCollided in ObjectsInCollision)
        {
            DealDamageToSingleTarget(objectCollided);
        }

        if (isRunning)
        {
            isRunning = false;
        }
    }

    private void DealDamageToSingleTarget(GameObject gameObjectCollided)
    {
        bool hitTarget = false;
        if (gameObjectCollided != transform.gameObject && gameObjectCollided != null)
        {
            if (gameObjectCollided.GetComponent<PlayerCharacter>() != null)
            {
                if (!objectsHasProcessed.Contains(gameObjectCollided))
                {
                    DamageReceiver damageReceiver = gameObjectCollided.GetComponent<DamageReceiver>(); 
                    if ( damageReceiver != null)
                    {
                        hitTarget = true;
                        damageReceiver.Analyze(damageData, transform.root);
                        objectsHasProcessed.Add(gameObjectCollided);
                    }
                }
            }
        }

        
    }

    public void Execute()
    {
        print("running ");
        objectsHasProcessed = new List<GameObject>();
        isRunning = true;
    }

 


    // public void StopDetectTargetManually()
    // {
        // isRunning = false;
        
    // }
}