using System;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSelectMapComponent : MonoBehaviour
{
    public int mapIndex;

    private SelectionPanelElement selectionPanelElement;

    public static Action<ClickToSelectMapComponent> onSelectMapComponent;
    
    private void Awake()
    {
        selectionPanelElement = GetComponent<SelectionPanelElement>();
        selectionPanelElement.onBeingClicked += SelectMap;
    }

    private void OnDestroy()
    {
        selectionPanelElement.onBeingClicked -= SelectMap;
    }

    /// <summary>
    /// Event Function
    /// </summary>
    /// <param name="pointer"></param>
    private void SelectMap(SelectionPointer pointer)
    {
        PlayerInputStorage.instance.SetMapIndexForInput(pointer.owner, mapIndex);
        pointer.Deactivate();
        onSelectMapComponent(this);
        if (PointerStorage.ActivatedPointerNumber == 0)
        {
            MenuStateMachine.OnStateChange(MenuState.MapVote);
        }

        // selectionPanelElement.DeleteFromLinkedList();
    }
}