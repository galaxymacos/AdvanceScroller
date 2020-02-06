using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PsychicHeroInput : MonoBehaviour
{
    private PlayerInputActions inputAction;
    public float horizontalMovement;
    public bool jump;
    public bool attack;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.Player2.Run.performed += OnRunOnperformed;
        inputAction.Player2.Run.canceled += OnRunOncanceled;
        
        inputAction.Player2.Jump.performed += ctx => jump = true;
        inputAction.Player2.Jump.canceled += ctx => jump = false;
        inputAction.Player2.Attack.performed += ctx => attack = true;
        inputAction.Player2.Attack.canceled += ctx => attack = false;
    }

    private void OnRunOnperformed(InputAction.CallbackContext ctx)
    {
        float rawMovement = ctx.ReadValue<float>();
        if (rawMovement > -0.3f && rawMovement < 0.3f)
        {
            rawMovement = 0f;
        }

        horizontalMovement = rawMovement;
    }

    private void OnRunOncanceled(InputAction.CallbackContext ctx)
    {
        float rawMovement = ctx.ReadValue<float>();
        if (rawMovement > -0.3f && rawMovement < 0.3f)
        {
            rawMovement = 0f;
        }

        horizontalMovement = rawMovement;
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
