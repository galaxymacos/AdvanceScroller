using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectionDialogBox : MonoBehaviour
{
    [SerializeField] private List<SelectionPanelPointer> pointers;
    [SerializeField] private List<SelectionPanelElement> selectionPanelElements;
    [SerializeField] private List<ChampionPanelElement> championPanelElements;

    private void Awake()
    {
        foreach (SelectionPanelPointer pointer in pointers)
        {
            pointer.onUIControlUpdate += PointerChanged;
        }

        foreach (SelectionPanelElement selectionPanelElement in selectionPanelElements)
        {
            selectionPanelElement.onUIControlUpdate += SelectionPanelElementChange;
        }

        foreach (ChampionPanelElement championPanelElement in championPanelElements)
        {
            championPanelElement.onUIControlUpdate += ChampionPanelElementChange;
        }
    }

    private void PointerChanged()
    {
        foreach (ChampionPanelElement championPanelElement in championPanelElements)
        {
            championPanelElement.ChangeToNonSelectedSprite();
        }

        foreach (SelectionPanelPointer pointer in pointers)
        {
            if (pointer.pointingElement.GetComponent<ChampionPanelElement>() != null)
            {
                pointer.pointingElement.GetComponent<ChampionPanelElement>().ChangeToSelectedSprite();
            }
        }

        foreach (var pointer in pointers)
        {
            if (pointer.choosen)
            {
                pointer.choosen = false;
                pointer.pointingElement.onBeingClicked?.Invoke(pointer);
            }
        }
        
    }

    private void SelectionPanelElementChange()
    {
    }

    private void ChampionPanelElementChange()
    {
        
    }
}