using UnityEngine;
using UnityEngine.InputSystem;

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
    
    public bool acceptInput = true;

    
    public virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
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