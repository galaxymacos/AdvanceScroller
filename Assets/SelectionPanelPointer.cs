using System;
using UnityEngine;

/// <summary>
/// This class is used to select the champion 
/// </summary>
public class SelectionPanelPointer : MonoBehaviour
{
    private NewPlayerInput owner;
    public SelectionPanelElement pointingElement;

    public void BindToOwnerInput(NewPlayerInput NewInput)
    {
        owner = NewInput;
        owner.onMoveUp += NavigateToTop;
        owner.onMoveDown += NavigateToDown;
        owner.onMoveLeft += NavigateToLeft;
        owner.onMoveRight += NavigateToRight;
        owner.onAttackButtonPressed += SetTargetChampion;
    }

    private void NavigateToLeft()
    {
        print("navigate to left");
        if (pointingElement.leftElement != null)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.leftElement;
            pointingElement.onSelected?.Invoke();
        }
        
    }
    
    public void NavigateToRight()
    {
        print("navigate to right");
        if (pointingElement.rightElement != null)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.rightElement;
            pointingElement.onSelected?.Invoke();
        }
        

    }

    private void NavigateToTop()
    {
        print("navigate to top");
        if (pointingElement.topElement != null)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.topElement;
            pointingElement.onSelected?.Invoke();
        }
        

    }
    

    private void NavigateToDown()
    {
        print("navigate to down");
        if (pointingElement.downElement != null)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.downElement;
            pointingElement.onSelected?.Invoke();

        }
    }

    public void SetTargetChampion()
    {
        if (!gameObject.activeSelf) return;
        print("select target champion");
        // SaveDataComposer.AddChampion(pointingElement.champion);
        PlayerInputStorage.instance.SetChampionForInput(owner, pointingElement.champion);
        SelectionPanelPointerManager.currentActivePointerNumber--;
        if (SelectionPanelPointerManager.currentActivePointerNumber == 0)
        {
            FightData fightData = SaveDataComposer.ToFightData();
            SaveSystem.SaveHeroSelectionData(fightData.SaveToString());
            SceneLoader.LoadFightingMapFromSavedData();
        }
        owner.onAttackButtonPressed -= SetTargetChampion;
        gameObject.SetActive(false);
    }


}