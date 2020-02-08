using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class KnockComponent : MonoBehaviour
{
    private Projectile projectile;
    public float knockHorizontalForce = 5f;
    public float knockVerticalForce = 5f;
    // Start is called before the first frame update
    private void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectile.onProjectileHitTarget += KnockUp;
    }

    public void KnockUp(GameObject target)
    {
        if (target.GetComponent<Knockable>() != null)
        {
            target.GetComponent<Knockable>().KnockUp(this);
        }
    }
}
