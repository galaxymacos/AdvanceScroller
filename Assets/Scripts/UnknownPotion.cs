using System;
using System.Collections.Generic;
using UnityEngine;

public class UnknownPotion : Item
{
    private float switchToNextPotionTime = 0.5f;
    private float switchToNextPotionTimeCounter;
    private int potionIndex;
    [SerializeField] private List<Item> items;
    private SpriteRenderer spriteRenderer;
    
    
    
    private void Awake()
    {
        switchToNextPotionTimeCounter = switchToNextPotionTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!hasBeenPickedUp)
        {
            ChangeForm();
        }
    }

    private void ChangeForm()
    {
        if (switchToNextPotionTimeCounter > 0)
        {
            switchToNextPotionTimeCounter -= Time.deltaTime;
            if (switchToNextPotionTimeCounter <= 0)
            {
                if (potionIndex >= items.Count - 1)
                {
                    potionIndex = 0;
                }
                else
                {
                    potionIndex++;
                }

                switchToNextPotionTimeCounter = switchToNextPotionTime;

                Refresh();
            }
        }
    }

    private void Refresh()
    {
        spriteRenderer.sprite = items[potionIndex].GetComponent<SpriteRenderer>().sprite;
    }

    public override void onBeingPickup(PlayerCharacter player)
    {
        items[potionIndex].onBeingPickup(player);
    }
    
    
}