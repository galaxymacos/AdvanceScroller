using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    // Spawn effect
    public GameObject explosion;
    public GameObject fire;
    public ParticleDisposer lightningParticleDisposer;


    public Transform explosionSpawnTransform;
    public Transform fireSpawnTransform;


    private void Awake()
    {
        lightningParticleDisposer.onParticleDistroy += SpawnExplosion;
    }

    private void Start()
    {
        InfiniteSoundPlayer.instance.PlaySound(AudioType.Lightning);
    }

    private void SpawnExplosion()
    {
        Instantiate(explosion, explosionSpawnTransform.position, Quaternion.identity);
        Instantiate(fire, fireSpawnTransform.position, Quaternion.identity);
    }
}
