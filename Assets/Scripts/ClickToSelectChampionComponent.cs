using System;
using UnityEngine;

[RequireComponent(typeof(SelectionPanelElement))]
public class ClickToSelectChampionComponent : MonoBehaviour
{
    public GameObject champion;

    private SelectionPanelElement selectionPanelElement;

    
    private void Awake()
    {
        selectionPanelElement = GetComponent<SelectionPanelElement>();
        selectionPanelElement.onBeingClicked += SelectChampion;
    }

    private void OnDestroy()
    {
        selectionPanelElement.onBeingClicked -= SelectChampion;

    }

    /// <summary>
    /// Event Function
    /// </summary>
    /// <param name="pointer"></param>
    private void SelectChampion(SelectionPointer pointer)
    {
        PlayerInputStorage.instance.SetChampionForInput(pointer.owner, champion);
        pointer.Deactivate();
        if (PointerStorage.ActivatedPointerNumber == 0)
        {
            MenuStateMachine.OnStateChange(MenuState.SelectMap);
            // FightData fightData = SaveDataComposer.ToFightData();
            // SaveSystem.SaveHeroSelectionData(fightData.SaveToString());
            // SceneLoader.LoadFightingMapFromSavedData();
        }
        selectionPanelElement.DeleteFromLinkedList();
    }
}