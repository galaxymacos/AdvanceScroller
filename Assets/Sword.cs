using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Projectile projectile;
    public GameObject swordDisapperPrefab;

    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectile.onProjectileHitTarget += GenerateParticle;
    }

    public void GenerateParticle(GameObject target)
    {
        if (target.GetComponent<PlayerCharacter>() != null)
        {
            Instantiate(swordDisapperPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
