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

    private void Awake()
    {
        onBeingClicked += MapBeingClick;
    }

    public void DeleteFromLinkedList()
    {
        leftElement.rightElement = rightElement;
        rightElement.leftElement = leftElement;

        foreach (SelectionPointer selectionPanelPointer in FindObjectsOfType<SelectionPointer>()) 
        {
            if (selectionPanelPointer!=null && selectionPanelPointer.PointingElement == this)
            {
                selectionPanelPointer.NavigateToRight();
            }
        }
    }

    private void MapBeingClick(SelectionPointer selectionPointer)
    {
        print(gameObject.name);
    }

  
}


