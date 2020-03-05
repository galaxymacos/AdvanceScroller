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
        print("test run");
        horizontalAxis = inputValue.Get<float>();
    }

    public void OnVerticalMovement(InputValue inputValue)
    {
        print("test vertical movement");
        verticalAxis = inputValue.Get<float>();
    }

    public void OnJump()
    {
        print("test jump start");
        jumpButtonPressed = true;
    }

    public void OnJumpRelease()
    {
        print("test jump end");
        jumpButtonPressed = false;
    }

    public void OnAttack()
    {
        print("test attack start");
        attackButtonPressed = true;
    }

    public void OnAttackRelease()
    {
        print("test attack release");
        attackButtonPressed = false;
    }

    public void OnDash()
    {
        print("test dash");
        dashButtonPressed = true;
    }

    public void OnDashRelease()
    {
        print("test dash release ");
        dashButtonPressed = false;
    }

    public void OnSkill1()
    {
        print("test skill 1");
        skill1ButtonPressed = true;
    }

    public void OnSkill1Release()
    {
        print("test skill 1 release");
        skill1ButtonPressed = false;
    }

    public void OnSkill2()
    {
        print("test skill 2");
        skill2ButtonPressed = true;
    }

    public void OnSkill2Release()
    {
        print("test skill 2 release");
        skill2ButtonPressed = false;
    }

    public void OnSkill3()
    {
        print("test skill3 ");
        skill3ButtonPressed = true;
    }

    public void OnSkill3Release()
    {
        print("test skill 3 release");
        skill3ButtonPressed = false;
    }

    public void OnSkill4()
    {
        print("test skill 4");
        skill4ButtonPressed = true;
    }

    public void OnSkill4Release()
    {
        print("test skill 4 release");

        skill4ButtonPressed = false;
    }


    public override void BindValueToInput()
    {
        
    }
}
