using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionDetector))]
public class SceneDealDamageComponent : MonoBehaviour
{
    public CollisionDetector collisionDetector;
    public DamageData damageData;
    private List<GameObject> objectsDealtDamageTo;
    public event Action onDamageDealt;
    
    private void Awake()
    {
        objectsDealtDamageTo = new List<GameObject>();
    }

    private void Update()
    {
        foreach (var objInCollision in collisionDetector.ObjectsInCollision)
        {
            var healthComponent = objInCollision.GetComponent<CharacterHealthComponent>();
            if (healthComponent != null && !objectsDealtDamageTo.Contains(objInCollision))
            {
                healthComponent.TakeDamage(damageData, transform, true);
                onDamageDealt?.Invoke();
                objectsDealtDamageTo.Add(objInCollision);
            }
        }
    }
}