using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BleedingHpBarColorModifier : MonoBehaviour
{
    private PlayerPanel playerPanel;
    private Image image;

    private BleedingEffectProcessor bleedingEffectProcessor;

    [SerializeField] private Color BleedingColor = Color.cyan;
    private Color originalColor;
    
    // Start is called before the first frame update
    private void Awake()
    {
        playerPanel = GetComponentInParent<PlayerPanel>();
        playerPanel.onPlayerSetup += BindToBleedingEvent; 
        image = GetComponent<Image>();

    }

    private void BindToBleedingEvent()
    {
        bleedingEffectProcessor = playerPanel.player.GetComponentInChildren<BleedingEffectProcessor>();
        if (bleedingEffectProcessor != null)
        {
            bleedingEffectProcessor.onStartBleeding += ChangeToBleedingColor;
            bleedingEffectProcessor.onEndBleeding += ChangeBackToOriginalColor;
        }
        
    }

    private void ChangeToBleedingColor()
    {
        originalColor = image.color;
        image.color = BleedingColor;
    }

    private void ChangeBackToOriginalColor()
    {
        image.color = originalColor;
    }
}
