using System;
using System.Collections;
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

    public void TornadoAttack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.Find("SpawnLocations").Find("Tornado").position, 0.5f);
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