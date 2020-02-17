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

    private Material material;

    private void Awake()
    {
        // sr = GetComponent<SpriteRenderer>();
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // if (sr.color.a > 0)
        // {
        //     var color = sr. color;
        //     color = new Color(color.r, color.g, color.b, color.a-Time.deltaTime*disappearSpeed);
        //     sr. color = color;
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }

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
