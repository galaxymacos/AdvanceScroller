using UnityEngine.InputSystem;

public class PlayerThreeInput : PlayerInput
{
    public override void BindValueToInput()
    {
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
    
    private void OnVerticalMovementCanceled(InputAction.CallbackContext ctx)
    {
        float rawMovement = ctx.ReadValue<float>();
        if (rawMovement > -0.3f && rawMovement < 0.3f)
        {
            rawMovement = 0f;
        }

        verticalAxis = rawMovement;
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