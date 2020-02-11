using System;
using System.Collections;
using UnityEngine;

public class PsychicHeroAnimationEventContainer : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    public GameObject knifePrefab;
    public GameObject axePrefab;
    public GameObject eyeBulletPrefab;
    public Transform spawnTransform;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void SpawnKnife()
    {
        GameObject knife = Instantiate(knifePrefab, spawnTransform.position, transform.rotation);
        var projectile = knife.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 30,0f);
    }
    
    public void SpawnAxes()
    { 
        GameObject generatedCross = Instantiate(axePrefab, transform.Find("SpawnLocations").Find("Axe").position, transform.rotation);
        Projectile projectile = generatedCross.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 20, 45f);
    }
    
    public void SpawnEyeBullet()
    { 
        GameObject generatedCross = Instantiate(eyeBulletPrefab, transform.Find("SpawnLocations").Find("Eye Bullet").position, transform.rotation);
        Projectile projectile = generatedCross.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 6, 0f);
    }
    
}