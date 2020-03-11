using System;
using UnityEngine;

/// <summary>
/// This class is used to select the champion 
/// </summary>
public class SelectionPointer : UIControl
{
    public NewPlayerInput owner;
    private SelectionPanelElement pointingElement;

    public SelectionPanelElement PointingElement => pointingElement;

    private bool isActivated = true;
    public bool IsActivated => isActivated;

    public Action onSetUp;

    private void BindToInput(NewPlayerInput NewInput)
    {
        owner = NewInput;
        owner.onMoveUp += NavigateToTop;
        owner.onMoveDown += NavigateToDown;
        owner.onMoveLeft += NavigateToLeft;
        owner.onMoveRight += NavigateToRight;
        owner.onAttackButtonPressed += SetTargetChampion;
    }

    private void OnDestroy()
    {
        owner.onMoveUp -= NavigateToTop;
        owner.onMoveDown -= NavigateToDown;
        owner.onMoveLeft -= NavigateToLeft;
        owner.onMoveRight -= NavigateToRight;
        owner.onAttackButtonPressed -= SetTargetChampion;
    }

    private void NavigateToLeft()
    {
        if (pointingElement.leftElement != null && isActivated)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.leftElement;
            pointingElement.onSelected?.Invoke();
        }
        
    }
    
    public void NavigateToRight()
    {
        if (pointingElement.rightElement != null && isActivated)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.rightElement;
            pointingElement.onSelected?.Invoke();
        }
        

    }

    private void NavigateToTop()
    {
        if (pointingElement.topElement != null && isActivated)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.topElement;
            pointingElement.onSelected?.Invoke();
        }
        

    }
    

    private void NavigateToDown()
    {
        print("Navigate to bottom");
        if (pointingElement.downElement != null && isActivated)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.downElement;
            pointingElement.onSelected?.Invoke();

        }
    }

    public void SetTargetChampion()
    {
        if (!IsActivated) return;
        owner.attackButtonPressed = false;
        isActivated = false;    
        pointingElement.onBeingClicked?.Invoke(this);

    }

    public void Deactivate()
    {
        isActivated = false;
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        isActivated = true;
        gameObject.SetActive(true);
        SetpointingElement(SelectionElementStorage.instance.FirstElement);
    }

    public void Setup(NewPlayerInput input)
    {
        BindToInput(input);
        Activate();
        onSetUp?.Invoke();
        // SetpointingElement(SelectionElementStorage.instance.FirstElement);
    }
    
    

    public void SetpointingElement(SelectionPanelElement element)
    {
        pointingElement = element;
        pointingElement.onSelected?.Invoke();
    }
}