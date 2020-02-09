using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Projectile projectile;

    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectile.onObjectCollided += DestroySword;
    }

    public void DestroySword(GameObject target)
    {    
        if (target != projectile.owner.gameObject && target.GetComponent<PlayerCharacter>()!=null)
        {
            Destroy(gameObject);
        }
    }
}
