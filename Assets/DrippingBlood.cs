using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DrippingBlood : MonoBehaviour
{
    private ParticleSystem ps;
    private BleedingEffectProcessor bep;
    
    private void Awake()
    {
        PlayerCharacterSpawner.onPlayerSpawnFinished+=Setup;
        ps = GetComponent<ParticleSystem>();
        bep = transform.root.GetComponentInChildren<BleedingEffectProcessor>();
        bep.onStartBleeding += TurnOn;
        bep.onEndBleeding += TurnOff;
    }

    private void OnDestroy()
    {
        bep.onStartBleeding -= TurnOn;
        bep.onEndBleeding -= TurnOff;
    }


    private void Setup()
    {
        var collision = ps.collision;
        collision.collidesWith = ~0;
        var layerToIgnore = transform.root.gameObject.layer;
        collision.collidesWith = ~(1<<layerToIgnore);
        ps.Stop();


    }



    private void TurnOn()
    {
        ps.Play();
    }

    private void TurnOff()
    {
        ps.Stop();
    }
}
