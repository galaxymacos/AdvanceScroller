using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class AutoLightingAdapter : UIControl
{
    private Light2D characterLight;
    private int pointerSelected;
    


    private void Awake()
    {
        var selectionPanelElement = GetComponent<SelectionPanelElement>();
        selectionPanelElement.onSelected += OnSelected;
        selectionPanelElement.onDeselected += OnDeselected;
        characterLight = GetComponent<Light2D>();
        characterLight.enabled = false;
    }


    private void OnSelected()
    {
        pointerSelected++;
        characterLight.enabled = true;
    }

    private void OnDeselected()
    {
        pointerSelected--;
        if (pointerSelected == 0)
        {
            characterLight.enabled = false;

        }
    }
}