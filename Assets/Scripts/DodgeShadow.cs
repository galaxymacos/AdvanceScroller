using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DodgeShadow : MonoBehaviour
{
    // private SpriteRenderer sr;
    public float disappearSpeed = 0.5f;
    private float fade = 1f;
    public float delay = 0.5f;

    private Material material;

    private void Awake()
    {
        // sr = GetComponent<SpriteRenderer>();
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            if (fade > 0)
            {
                fade -= disappearSpeed * Time.deltaTime;
                material.SetFloat("_Fade", fade);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        
        
        
    }
}
