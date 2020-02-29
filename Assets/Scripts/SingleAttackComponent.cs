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
        if (objectsInCollision == null) return;
        
        
        foreach (GameObject objectCollided in objectsInCollision)
        {
            DealDamageToSingleTarget(objectCollided);
        }
    }

    private void DealDamageToSingleTarget(GameObject gameObjectCollided)
    {
        
        if (gameObjectCollided != transform.gameObject && gameObjectCollided != null)
        {
            if (gameObjectCollided.GetComponent<PlayerCharacter>() != null)
            {
                if (!objectsHasProcessed.Contains(gameObjectCollided))
                {
                    gameObjectCollided.GetComponent<DamageReceiver>()?.Analyze(damageData, transform.root);
                    objectsHasProcessed.Add(gameObjectCollided);
                }
            }
        }
    }

    public void Execute()
    {
        objectsHasProcessed = new List<GameObject>();
        isRunning = true;
    }

    
 
    public void StopDetectTargetManually()
    {
        isRunning = false;
        
    }
}