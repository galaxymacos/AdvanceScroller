using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DodgeShadow : MonoBehaviour
{
    private SpriteRenderer sr;
    public float disappearSpeed = 1f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.color.a > 0)
        {
            var color = sr. color;
            color = new Color(color.r, color.g, color.b, color.a-Time.deltaTime*disappearSpeed);
            sr. color = color;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
