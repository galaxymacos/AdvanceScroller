using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    // Spawn effect
    public GameObject explosion;
    private float explosionDelay = 0.4f;
    public ParticleDisposer lightningParticleDisposer;


    public Transform explosionSpawnTransform;
    

    private void Update()
    {
        if (explosionDelay > 0)
        {
            explosionDelay -= Time.deltaTime;
            if (explosionDelay <= 0)
            {
                SpawnLightningAfterEffect();
            }
        }
    }


    private void Start()
    {
        InfiniteSoundPlayer.instance.PlaySound(AudioType.Lightning);
    }

    private void SpawnLightningAfterEffect()
    {
        Instantiate(explosion, explosionSpawnTransform.position, Quaternion.identity);
        
        lightningParticleDisposer.onParticleDistroy -= SpawnLightningAfterEffect;

    }


   
}
