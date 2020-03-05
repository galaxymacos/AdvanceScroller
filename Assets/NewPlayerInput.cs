using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerInput : MonoBehaviour
{
    public static int PlayerInputID = 0;

    [HideInInspector] public float horizontalAxis;
    [HideInInspector] public float verticalAxis;
    [HideInInspector] public bool jumpButtonPressing;
    [HideInInspector] public bool attackButtonPressing;
    [HideInInspector] public bool dashButtonPressing;
    [HideInInspector] public bool skill1ButtonPressing;
    [HideInInspector] public bool skill2ButtonPressing;
    [HideInInspector] public bool skill3ButtonPressing;
    [HideInInspector] public bool skill4ButtonPressing;

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
        jumpButtonPressing = true;
    }

    public void OnJumpRelease()
    {
        print("test jump end");
        jumpButtonPressing = false;
    }

    public void OnAttack()
    {
        print("test attack start");
        attackButtonPressing = true;
    }

    public void OnAttackRelease()
    {
        print("test attack release");
        attackButtonPressing = false;
    }

    public void OnDash()
    {
        print("test dash");
        dashButtonPressing = true;
    }

    public void OnDashRelease()
    {
        print("test dash release ");
        dashButtonPressing = false;
    }

    public void OnSkill1()
    {
        print("test skill 1");
        skill1ButtonPressing = true;
    }

    public void OnSkill1Release()
    {
        print("test skill 1 release");
        skill1ButtonPressing = false;
    }

    public void OnSkill2()
    {
        print("test skill 2");
        skill2ButtonPressing = true;
    }

    public void OnSkill2Release()
    {
        print("test skill 2 release");
        skill2ButtonPressing = false;
    }

    public void OnSkill3()
    {
        print("test skill3 ");
        skill3ButtonPressing = true;
    }

    public void OnSkill3Release()
    {
        print("test skill 3 release");
        skill3ButtonPressing = false;
    }

    public void OnSkill4()
    {
        print("test skill 4");
        skill4ButtonPressing = true;
    }

    public void OnSkill4Release()
    {
        print("test skill 4 release");

        skill4ButtonPressing = false;
    }
    
    
    
}
