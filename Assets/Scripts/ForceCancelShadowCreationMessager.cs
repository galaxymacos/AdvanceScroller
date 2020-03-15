using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ForceCancelShadowCreationMessager : MonoBehaviour
{ 
    [HideInInspector] public SpriteRenderer sr;
    public static Action<ForceCancelShadowCreationMessager> onForceCancelshadowCreated;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        onForceCancelshadowCreated?.Invoke(this);
    }


    public void Setup(SpriteRenderer spriteCopyToShadow)
    {
        transform.localScale = spriteCopyToShadow.transform.localScale;
        GetComponent<SpriteRenderer>().sprite = spriteCopyToShadow.sprite;
    }
}