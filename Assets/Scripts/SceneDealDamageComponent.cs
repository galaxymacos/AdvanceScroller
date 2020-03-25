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
    public bool activateInAwake;
    private bool isActive;
    private PlayerCharacter owner;

    public void SetOwner(PlayerCharacter _owner)
    {
        owner = _owner;
    }
    private void Awake()
    {
        objectsDealtDamageTo = new List<GameObject>();
        if (activateInAwake)
        {
            isActive = true;
        }
    }

    public void SetActive(bool _isActive)
    {
        isActive = _isActive;
    }

    private void Update()
    {
        if (isActive)
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
}