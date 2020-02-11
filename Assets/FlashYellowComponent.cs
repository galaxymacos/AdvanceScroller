using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent), typeof(SpriteRenderer))]
public class FlashYellowComponent : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private HealthComponent healthComponent;

    [SerializeField]
    private Sprite yellowSprite;
    private Sprite tempSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.onTakeDamage += FlashYellow;
    }

    public bool isFlashing;
    
    public void FlashYellow()
    {
        print("flashing yellow");
        isFlashing = true;
        spriteRenderer.sprite = yellowSprite;
        
        Invoke(nameof(FlashBack), 0.15f);
    }
    
    private void FlashBack()
    {
        isFlashing = false;
        spriteRenderer.sprite = tempSprite;
    }
    
    
}
