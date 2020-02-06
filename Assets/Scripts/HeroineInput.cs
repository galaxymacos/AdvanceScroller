using System;
using UnityEngine;

public class HeroineInput: MonoBehaviour
{
    private PlayerInputActions inputAction;
    public float horizontalMovement;
    public bool jump;
    public bool attack;
    public bool hurt;
    
    private void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.Player.Run.performed += ctx => horizontalMovement = ctx.ReadValue<float>();
        inputAction.Player.Jump.performed += ctx => jump = true;
        inputAction.Player.Jump.canceled += ctx => jump = false;
        inputAction.Player.Attack.performed += ctx => attack = true;
        inputAction.Player.Attack.canceled += ctx => attack = false;
        
        inputAction.Player.Hurt.performed += ctx => hurt = true;
        inputAction.Player.Hurt.canceled += ctx => hurt = false;
    }
    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}

