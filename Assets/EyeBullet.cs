using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EyeBullet : MonoBehaviour
{
    [SerializeField] private float multiplier = 3f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void IncreaseSpeed()
    {
        rb.velocity *= multiplier;
    }
}
