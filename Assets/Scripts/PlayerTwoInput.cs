using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTwoInput : PlayerInput
{
    public override void BindValueToInput()
    {
        inputAction.Player2.Run.performed += ctx => horizontalAxis = ctx.ReadValue<float>();
        inputAction.Player2.Run.canceled += OnRunOncanceled;
        inputAction.Player2.Jump.performed += ctx => jumpButtonPressed = true;
        inputAction.Player2.Jump.canceled += ctx => jumpButtonPressed = false;
        inputAction.Player2.Attack.performed += ctx => attackButtonPressed = true;
        inputAction.Player2.Attack.canceled += ctx => attackButtonPressed = false;
        inputAction.Player2.Dash.performed += ctx => dashButtonPressed = true;
        inputAction.Player2.Dash.canceled += ctx => dashButtonPressed = false;
        inputAction.Player2.Skill1.performed += ctx => skill1ButtonPressed = true;
        inputAction.Player2.Skill1.canceled += ctx => skill1ButtonPressed = false;
        inputAction.Player2.Skill2.performed += ctx => skill2ButtonPressed = true;
        inputAction.Player2.Skill2.canceled += ctx => skill2ButtonPressed = false;
        inputAction.Player2.Skill3.performed += ctx => skill3ButtonPressed = true;
        inputAction.Player2.Skill3.canceled += ctx => skill3ButtonPressed = false;
        inputAction.Player2.Skill4.performed += ctx => skill4ButtonPressed = true;
        inputAction.Player2.Skill4.canceled += ctx => skill4ButtonPressed = false;
    }

    private void OnRunOncanceled(InputAction.CallbackContext ctx)
    {
        float rawMovement = ctx.ReadValue<float>();
        if (rawMovement > -0.3f && rawMovement < 0.3f)
        {
            rawMovement = 0f;
        }

        horizontalAxis = rawMovement;
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
