using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DodgeShadow : MonoBehaviour
{
    private Material mat;
    [SerializeField] private float fadeSpeed = 80;
    [SerializeField] private float pixelateSizeInFloat = 160;
    private void Awake()
    {
        print("dodge shadow is created");
        mat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (pixelateSizeInFloat > 0)
        {
            pixelateSizeInFloat -= fadeSpeed * Time.deltaTime;
            mat.SetInt("_PixelateSize", Mathf.Max((int)pixelateSizeInFloat, 0));
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
