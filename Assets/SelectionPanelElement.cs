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

    public Action<SelectionPointer> onBeingClicked;
    

    public void DeleteFromLinkedList()
    {
        leftElement.rightElement = rightElement;
        rightElement.leftElement = leftElement;

        foreach (SelectionPointer selectionPanelPointer in PointerStorage.pointers)
        {
            if (selectionPanelPointer!=null && selectionPanelPointer.PointingElement == this)
            {
                selectionPanelPointer.NavigateToRight();
            }
        }
    }

  
}


