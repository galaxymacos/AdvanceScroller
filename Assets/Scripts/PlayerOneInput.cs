using System;

public class PlayerOneInput: PlayerInput
{
    public override void BindValueToInput()
    {
        inputAction.Player.Run.performed += ctx => horizontalAxis = ctx.ReadValue<float>();
        inputAction.Player.Run.canceled += ctx => horizontalAxis = 0;
        inputAction.Player.VerticalMovement.performed += ctx => verticalAxis = ctx.ReadValue<float>();
        inputAction.Player.VerticalMovement.canceled += ctx => verticalAxis = 0;
        inputAction.Player.Jump.performed += ctx => jumpButtonPressed = true;
        inputAction.Player.Jump.canceled += ctx => jumpButtonPressed = false;
        inputAction.Player.Dash.performed += ctx => dashButtonPressed = true;
        inputAction.Player.Dash.canceled += ctx => dashButtonPressed = false;
        inputAction.Player.Attack.performed += ctx => attackButtonPressed = true;
        inputAction.Player.Attack.canceled += ctx => attackButtonPressed = false;
        inputAction.Player.Skill1.performed += ctx => skill1ButtonPressed = true;
        inputAction.Player.Skill1.canceled += ctx => skill1ButtonPressed = false;
        inputAction.Player.Skill2.performed += ctx => skill2ButtonPressed = true;
        inputAction.Player.Skill2.canceled += ctx => skill2ButtonPressed = false;
        inputAction.Player.Skill3.performed += ctx => skill3ButtonPressed = true;
        inputAction.Player.Skill3.canceled += ctx => skill3ButtonPressed = false;
        inputAction.Player.Skill4.performed += ctx => skill4ButtonPressed = true;
        inputAction.Player.Skill4.canceled += ctx => skill4ButtonPressed = false;
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