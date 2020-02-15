using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParticleSpawner : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<HealthComponent>().onTakeDamage += SpawnBloodExplosionPrefab;
    }

    public void SpawnBloodExplosionPrefab()
    {
        Instantiate(ParticleSpawner.Instance.BloodExplosion, transform.position, transform.rotation);
    }
}
