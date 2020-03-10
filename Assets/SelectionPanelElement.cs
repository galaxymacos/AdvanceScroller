using System;
using System.Collections;
using UnityEngine;

public class SelectionPanelElement : UIControl
{
    public SelectionPanelElement leftElement;
    public SelectionPanelElement rightElement;
    public SelectionPanelElement topElement;
    public SelectionPanelElement downElement;

    
    
    public Action onSelected;
    public Action onDeselected;

    public Action<SelectionPanelPointer> onBeingClicked;
    

    public void RebindSelectionPanelElement()
    {
        leftElement.rightElement = rightElement;
        rightElement.leftElement = leftElement;

        foreach (SelectionPanelPointer selectionPanelPointer in SelectionPanelPointerManager.instance
            .selectionPanelPointers)
        {
            if (selectionPanelPointer.pointingElement == this)
            {
                selectionPanelPointer.NavigateToRight();
            }
        }
    }

  
}


