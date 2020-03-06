using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerInput : PlayerInput
{
    public static int PlayerInputID = 0;
    

    private void Start()
    {
        PlayerInputDistributor.instance.DistributeInput(this);
    }

    public void OnRun(InputValue inputValue)
    {
        var horizontalAxisTemporary = inputValue.Get<float>();
        if (horizontalAxisTemporary > 0.5)
        {
            horizontalAxis = 1;
        }
        else if (horizontalAxisTemporary > -0.5 && horizontalAxisTemporary < 0.5)
        {
            horizontalAxis = 0;
        }
        else
        {
            horizontalAxis = -1;
        }
        Debug.Log(horizontalAxis);
    }

    public void OnVerticalMovement(InputValue inputValue)
    {
        var verticalAxisTemporary = inputValue.Get<float>();
        if (verticalAxisTemporary > 0.5)
        {
            verticalAxis = 1;
        }
        else if (verticalAxisTemporary > -0.5 && verticalAxisTemporary < 0.5)
        {
            verticalAxis = 0;
        }
        else
        {
            verticalAxis = -1;
        }
    }

    public void OnJump()
    {
        jumpButtonPressed = true;
    }

    public void OnJumpRelease()
    {
        jumpButtonPressed = false;
    }

    public void OnAttack()
    {
        attackButtonPressed = true;
    }

    public void OnAttackRelease()
    {
        attackButtonPressed = false;
    }

    public void OnDash()
    {
        dashButtonPressed = true;
    }

    public void OnDashRelease()
    {
        dashButtonPressed = false;
    }

    public void OnSkill1()
    {
        skill1ButtonPressed = true;
    }

    public void OnSkill1Release()
    {
        skill1ButtonPressed = false;
    }

    public void OnSkill2()
    {
        skill2ButtonPressed = true;
    }

    public void OnSkill2Release()
    {
        skill2ButtonPressed = false;
    }

    public void OnSkill3()
    {
        skill3ButtonPressed = true;
    }

    public void OnSkill3Release()
    {
        skill3ButtonPressed = false;
    }

    public void OnSkill4()
    {
        skill4ButtonPressed = true;
    }

    public void OnSkill4Release()
    {

        skill4ButtonPressed = false;
    }


    public override void BindValueToInput()
    {
        
    }
}
