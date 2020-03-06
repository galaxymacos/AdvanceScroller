using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPrincessParticleSpawner : MonoBehaviour
{
    public GameObject wolf;
    
    
    public GameObject cross;
    

    private PlayerCharacter playerCharacter;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void SpawnWolf()
    { 
        GameObject generatedWolf = Instantiate(wolf, transform.Find("SpawnLocations").Find("Wolf").position, transform.rotation);
        Projectile projectile = generatedWolf.GetComponent<Projectile>();
        if (playerCharacter.playerInput.verticalAxis > 0)
        {
            projectile.Setup(playerCharacter, 13, 45);
        }
        else if(playerCharacter.playerInput.verticalAxis < 0)
        {
            projectile.Setup(playerCharacter, 13, -45);
        }
        else
        {
            projectile.Setup(playerCharacter, 13, 0);
        }
    }
    
    public void SpawnCross()
    { 
        GameObject generatedCross = Instantiate(cross, transform.Find("SpawnLocations").Find("Cross").position, transform.rotation);
        Projectile projectile = generatedCross.GetComponent<Projectile>();
        if (playerCharacter.playerInput.verticalAxis > 0)
        {
            projectile.Setup(playerCharacter, 18, 30);
        }
        else if(playerCharacter.playerInput.verticalAxis < 0)
        {
            projectile.Setup(playerCharacter, 18, -30);
        }
        else
        {
            projectile.Setup(playerCharacter, 18, 0);
        }
    }
    
}
