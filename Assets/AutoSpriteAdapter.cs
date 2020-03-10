using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionPanelElement), typeof(SpriteRenderer))]
public class AutoSpriteAdapter : UIControl
{

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
