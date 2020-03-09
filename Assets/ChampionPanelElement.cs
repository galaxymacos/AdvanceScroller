using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionPanelElement))]
public class ChampionPanelElement : MonoBehaviour
{
    // public List<SelectionPanelPointer> pointers = new List<SelectionPanelPointer>();

    private int pointerSelected = 0;
    public Sprite nonSelected;
    public Sprite selected;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        var selectionPanelElement = GetComponent<SelectionPanelElement>();
        selectionPanelElement.onSelected += OnSelected;
        selectionPanelElement.onDeselected += OnDeselected;
        GetComponent<ClickToSelectChampionComponent>().onChampionSelected += DisableIcon;
    }

    private void DisableIcon(ClickToSelectChampionComponent clickToSelectChampionComponent)
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }

    private void OnSelected()
    {
        pointerSelected++;
        spriteRenderer.sprite = selected;
    }

    private void OnDeselected()
    {
        pointerSelected--;
        if (pointerSelected == 0)
        {
            spriteRenderer.sprite = nonSelected;
        }
    }
    
    
}
