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
    public ContinuousAttack tornado;
    public GameObject chargedDaggerPrefab;
    public GameObject chargedAxePrefab;

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
    
    public void SpawnChargedAxe()
    { 
        GameObject axe = Instantiate(chargedAxePrefab, transform.Find("SpawnLocations").Find("Axe").position, transform.rotation);
        Projectile projectile = axe.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 20f, 0);
        ProjectileReturnableComponent boomrang = axe.GetComponent<ProjectileReturnableComponent>();
        boomrang.Setup();
    }
    
    public void SpawnEyeBullet()
    { 
        GameObject generatedCross = Instantiate(eyeBulletPrefab, transform.Find("SpawnLocations").Find("Eye Bullet").position, transform.rotation);
        Projectile projectile = generatedCross.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 6, 0f);
    }

    public void SpawnChargedDagger()
    {
        GameObject chargedDagger = Instantiate(chargedDaggerPrefab, spawnTransform.position, transform.rotation);
        var daggerRotator = chargedDagger.GetComponent<DaggerRotator>();
        daggerRotator.Setup(playerCharacter);
        playerCharacter.chargedDagger = chargedDagger;
    }

    public void ExecuteTornado()
    {
        tornado.Execute();
    }

    public void StopExecutingTornado()
    {
        tornado.StopDetectTarget();
    }
}