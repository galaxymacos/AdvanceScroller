using UnityEngine;

/// <summary>
/// This class is used to select the champion 
/// </summary>
public class SelectionPanelPointer : MonoBehaviour
{
    private NewPlayerInput owner;
    public int ownerPlayerIndex;
    public SelectionPanelElement pointingElement;

    public void SetInput(NewPlayerInput NewInput)
    {
        owner = NewInput;
        owner.onMoveUp += NavigateToTop;
        owner.onMoveDown += NavigateToDown;
        owner.onMoveLeft += NavigateToLeft;
        owner.onMoveRight += NavigateToRight;
        owner.onAttackButtonPressed += SetTargetChampion;
    }

    public void NavigateToLeft()
    {
        print("navigate to left");
        if (pointingElement.leftElement != null)
        {
            pointingElement = pointingElement.leftElement;
        }
    }
    
    public void NavigateToRight()
    {
        print("navigate to right");
        if (pointingElement.rightElement != null)
        {
            pointingElement = pointingElement.rightElement;
        }
    }

    
    public void NavigateToTop()
    {
        print("navigate to top");
        if (pointingElement.topElement != null)
        {
            pointingElement = pointingElement.topElement;
        }
    }

    
    public void NavigateToDown()
    {
        print("navigate to down");
        if (pointingElement.downElement != null)
        {
            pointingElement = pointingElement.downElement;
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