using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionPanelElement))]
public class ChampionPanelElement : MonoBehaviour
{
    public Sprite nonSelected;
    public Sprite selected;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        var selectionPanelElement = GetComponent<SelectionPanelElement>();
        selectionPanelElement.onSelected += () => spriteRenderer.sprite = selected;
        selectionPanelElement.onDeselected += ()=>spriteRenderer.sprite = nonSelected;
        
    }
    
    
}
