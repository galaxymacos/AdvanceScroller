using System;
using Sprites;
using UnityEngine;

/// <summary>
/// This class is used to select the champion 
/// </summary>
public class SelectionPointer : UIControl
{
    public NewPlayerInput owner;
    [SerializeField] private SelectionPanelElement pointingElement;

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
        if (gameObject.activeSelf == false) return;
        print("navigate to left");
        if (pointingElement.leftElement != null && isActivated)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.leftElement;
            pointingElement.onSelected?.Invoke();
            AudioController.instance.PlayAudio(AudioType.Pointer_Move);

        }
        
    }
    
    public void NavigateToRight()
    {
        if (gameObject.activeSelf == false) return;
        print("navigate to right");
        if (pointingElement.rightElement != null && isActivated)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.rightElement;
            pointingElement.onSelected?.Invoke();
            AudioController.instance.PlayAudio(AudioType.Pointer_Move);

        }
        

    }

    private void NavigateToTop()
    {
        if (gameObject.activeSelf == false) return;
        print("navigate to top");
        if (pointingElement.topElement != null && isActivated)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.topElement;
            pointingElement.onSelected?.Invoke();
            AudioController.instance.PlayAudio(AudioType.Pointer_Move);

        }
        

    }
    

    private void NavigateToDown()
    {
        if (gameObject.activeSelf == false) return;
        print("Navigate to bottom");
        if (pointingElement.downElement != null && isActivated)
        {
            pointingElement.onDeselected?.Invoke();
            pointingElement = pointingElement.downElement;
            pointingElement.onSelected?.Invoke();
            AudioController.instance.PlayAudio(AudioType.Pointer_Move);

        }
    }

    public void SetTargetChampion()
    {

        if (!OnePlayerTest.IsInDebugMode)
        {
            if (!IsActivated || PointerCounter.PointerNum <= 1) return;
        }
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
        print("Pointer has been activated and pointed to the first element, which is "+ SelectionElementStorage.instance.FirstElement.gameObject. name);
        SetpointingElement(SelectionElementStorage.instance.FirstElement);
    }

    public void Setup(NewPlayerInput input)
    {
        BindToInput(input);
        PointerStorage.pointers.Add(this);
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