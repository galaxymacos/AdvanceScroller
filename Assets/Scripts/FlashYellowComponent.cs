using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterHealthComponent), typeof(SpriteRenderer))]
public class FlashYellowComponent : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private CharacterHealthComponent characterHealthComponent;

    [SerializeField]
    private Sprite yellowSprite;
    private Sprite tempSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterHealthComponent = GetComponent<CharacterHealthComponent>();
        characterHealthComponent.onTakeDamage += FlashYellow;
    }

    public bool isFlashing;
    
    public void FlashYellow(CharacterHealthComponent characterHealthComponent)
    {
        print("flash yellow");
        isFlashing = true;
        spriteRenderer.sprite = yellowSprite;
        
        // Invoke(nameof(FlashBack), 0.15f);
    }

    private void Update()
    {
        spriteRenderer.sprite = yellowSprite;
        isFlashing = true;


    }

    private void FlashBack()
    {
        isFlashing = false;
        spriteRenderer.sprite = tempSprite;
    }
    
    
}
