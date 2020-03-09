using System;
using UnityEngine;

[RequireComponent(typeof(SelectionPanelElement))]
public class ClickToSelectChampionComponent : MonoBehaviour
{
    public GameObject champion;

    private SelectionPanelElement selectionPanelElement;

    public Action<ClickToSelectChampionComponent> onChampionSelected;
    
    private void Awake()
    {
        selectionPanelElement = GetComponent<SelectionPanelElement>();
        selectionPanelElement.onBeingClicked += SelectChampion;
    }

    private void SelectChampion(SelectionPanelPointer pointer)
    {
        PlayerInputStorage.instance.SetChampionForInput(pointer.owner, champion);
        SelectionPanelPointerManager.currentActivePointerNumber--;
        if (SelectionPanelPointerManager.currentActivePointerNumber == 0)
        {
            FightData fightData = SaveDataComposer.ToFightData();
            SaveSystem.SaveHeroSelectionData(fightData.SaveToString());
            SceneLoader.LoadFightingMapFromSavedData();
        }
        pointer.owner.onAttackButtonPressed -= pointer.SetTargetChampion;
        pointer.gameObject.SetActive(false);
        
        onChampionSelected?.Invoke(this);
        selectionPanelElement.RebindSelectionPanelElement();
    }
}