using UnityEngine;

/// <summary>
/// This class is used to select the champion 
/// </summary>
public class SelectionPanelPointer : UIControl
{
    public NewPlayerInput owner;
    public SelectionPanelElement pointingElement;
    public bool enable = true;
    public bool choosen;

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
        if (pointingElement.leftElement != null && enable)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.leftElement;
            pointingElement.onSelected?.Invoke();
        }
        
    }
    
    public void NavigateToRight()
    {
        print("navigate to right");
        if (pointingElement.rightElement != null && enable)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.rightElement;
            pointingElement.onSelected?.Invoke();
        }
        

    }

    private void NavigateToTop()
    {
        print("navigate to top");
        if (pointingElement.topElement != null && enable)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.topElement;
            pointingElement.onSelected?.Invoke();
        }
        

    }
    

    private void NavigateToDown()
    {
        print("navigate to down");
        if (pointingElement.downElement != null && enable)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.downElement;
            pointingElement.onSelected?.Invoke();

        }
    }

    public void SetTargetChampion()
    {
        choosen = true;
        
        owner.attackButtonPressed = false;
        if (!gameObject.activeSelf) return;
        enable = false;    
        pointingElement.onBeingClicked?.Invoke(this);

    }
    
}