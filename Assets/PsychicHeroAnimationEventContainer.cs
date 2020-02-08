using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicHeroAnimationEventContainer : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    public GameObject knifePrefab;
    public Transform spawnTransform;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void SpawnKnife()
    {
        GameObject knife = Instantiate(knifePrefab, spawnTransform.position, transform.rotation);
        var projectile = knife.GetComponent<Projectile>();
        projectile.Setup(playerCharacter);
    }
}
