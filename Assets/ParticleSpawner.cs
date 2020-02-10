using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject playerDieDust;

    public static ParticleSpawner Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void SpawnPlayerParticle(GameObject particle, PlayerCharacter player)
    {
        GameObject newParticle = Instantiate(particle, player.transform.Find("SpawnLocations").Find("DieDust").position, player.transform.rotation);
        newParticle.GetComponent<ParticleFacingComponent>().Setup(player);
    }
}
