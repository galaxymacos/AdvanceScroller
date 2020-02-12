using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    private Projectile projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<Projectile>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Knockable>() != null && other.gameObject != projectile.owner.gameObject)
        {
            // Instantiate(crossExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    
}
