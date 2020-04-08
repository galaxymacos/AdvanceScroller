using System;
using UnityEngine;

[RequireComponent(typeof(IceSlideTrigger))]
public class SnowBallSetuper : MonoBehaviour
{
    private PlayerCharacter owner;

    private void Awake()
    {
        IceSlideEventSystem.onIceSlideStart += Setup;
        IceSlideEventSystem.onGameObjectDropped += SetOwnerToSnowBall;
    }

    private void OnDestroy()
    {
        IceSlideEventSystem.onIceSlideStart -= Setup;
        IceSlideEventSystem.onGameObjectDropped -= SetOwnerToSnowBall;
    }

    private void SetOwnerToSnowBall(GameObject objDropped)
    {
        SceneDealDamageComponent sceneDealDamageComponent = objDropped.GetComponent<SceneDealDamageComponent>();
        sceneDealDamageComponent.SetOwner(owner);
        sceneDealDamageComponent.SetActive(true);
    }

    private void Setup()
    {
        owner = GetComponent<IceSlideTrigger>().Owner;
        
    }
}
