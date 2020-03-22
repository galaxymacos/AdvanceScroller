using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ForceCancelShadowCreationMessager : MonoBehaviour
{ 
    [HideInInspector] public SpriteRenderer sr;
    public static Action<ForceCancelShadowCreationMessager> onForceCancelshadowCreated;
    public float lastTime = 2f;
    public float lastTimeCounter;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        lastTimeCounter = lastTime;
    }


    private void Update()
    {
        if (lastTimeCounter > 0)
        {
            lastTimeCounter -= Time.deltaTime;
            if (lastTimeCounter <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


    public void Setup(SpriteRenderer spriteCopyToShadow)
    {
        transform.localScale = spriteCopyToShadow.transform.localScale;
        GetComponent<SpriteRenderer>().sprite = spriteCopyToShadow.sprite;
    }
}