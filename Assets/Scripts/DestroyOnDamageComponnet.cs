using System;
using UnityEngine;

[RequireComponent(typeof(SceneDealDamageComponent))]
public class DestroyOnDamageComponnet: MonoBehaviour
{
    private SceneDealDamageComponent sceneDealDamageComponent;
    private void Awake()
    {
        sceneDealDamageComponent = GetComponent<SceneDealDamageComponent>();
        sceneDealDamageComponent.onDamageDealt += DestroyGameObject;
    }

    private void OnDestroy()
    {
        sceneDealDamageComponent.onDamageDealt -= DestroyGameObject;
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}