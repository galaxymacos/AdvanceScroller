using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPrincess : MonoBehaviour
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
        projectile.Setup(playerCharacter, 5, 0);
    }
    
    public void SpawnCross()
    { 
        GameObject generatedCross = Instantiate(cross, transform.Find("SpawnLocations").Find("Cross").position, transform.rotation);
        Projectile projectile = generatedCross.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 5, 0);
    }

    public void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.Find("SpawnLocations").Find("Attack").position, 0.5f);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != gameObject)
            {
                hitCollider.GetComponent<HealthComponent>()?.TakeDamage(10);
                hitCollider.GetComponent<Knockable>()?.KnockUp(5,5,transform);
            }
            
        }
    }
}
