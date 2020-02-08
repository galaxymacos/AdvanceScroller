using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPrincessAnimationEventContainer : MonoBehaviour
{
    public GameObject wolf;
    private PlayerCharacter playerCharacter;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void SpawnWolf()
    { 
        GameObject generatedWolf = Instantiate(wolf, transform.Find("SpawnLocations").Find("Wolf").position, transform.rotation);
        Projectile projectile = generatedWolf.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 5, 0);
    }
}
