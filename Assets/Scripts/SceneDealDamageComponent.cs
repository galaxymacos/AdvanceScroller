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

        collisionDetector.onObjectCollided += TryDealDamage;
    }

    public void SetActive(bool _isActive)
    {
        isActive = _isActive;
    }

    private void TryDealDamage(GameObject objToCollided)
    {
        if (!isActive) return;
        print("Try deal damage to "+objToCollided.name);
        var targetDamageReceiver = objToCollided.GetComponent<CharacterDamageReceiver>();
        if (targetDamageReceiver != null && !objectsDealtDamageTo.Contains(objToCollided) && targetDamageReceiver.GetComponent<PlayerCharacter>() != owner)
        {
            targetDamageReceiver.Analyze(damageData, transform);
            objectsDealtDamageTo.Add(objToCollided);
            onDamageDealt?.Invoke();
        }
    }
}