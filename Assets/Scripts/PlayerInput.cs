using UnityEngine;

public abstract class PlayerInput: MonoBehaviour
{
    protected PlayerInputActions inputAction;
    [HideInInspector] public float horizontalAxis;
    [HideInInspector] public float verticalAxis;
    [HideInInspector] public bool jumpButtonPressed;
    [HideInInspector] public bool attackButtonPressed;
    [HideInInspector] public bool dashButtonPressed;
    [HideInInspector] public bool skill1ButtonPressed;
    [HideInInspector] public bool skill2ButtonPressed;
    [HideInInspector] public bool skill3ButtonPressed;
    [HideInInspector] public bool skill4ButtonPressed;
    
    public virtual void Awake()
    {
        inputAction = new PlayerInputActions();
        BindValueToInput();

    }

    public abstract void BindValueToInput();
    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}