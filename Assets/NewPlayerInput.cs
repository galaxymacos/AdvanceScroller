using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewPlayerInput : PlayerInput
{
    public static int PlayerInputID = 0;

    public Action onMoveRight;
    public Action onMoveLeft;
    public Action onMoveUp;
    public Action onMoveDown;
    public Action onAttackButtonPressed;


    
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            print("distribute a player input to the ui");
            PlayerInputDistributor.instance.DistributeInputToChampionSelectionUI(this);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerInputDistributor.instance.DistributeInputToPlayerCharacter(this);
        }
    }

    public void OnRun(InputValue inputValue)
    {
        if (!acceptInput) return;
        
        float previousHorizontalAxis = horizontalAxis;
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

        if (Math.Abs(horizontalAxis - 1) < Mathf.Epsilon && previousHorizontalAxis < 1)
        {
            print("move right");
            onMoveRight?.Invoke();
        }
        else if (Math.Abs(horizontalAxis + 1) < Mathf.Epsilon && previousHorizontalAxis > -1)
        {
            print("move left");
            onMoveLeft?.Invoke();
        }
        
    }

    public void OnVerticalMovement(InputValue inputValue)
    {
        if (!acceptInput) return;

        
        float previousVerticalAxis = verticalAxis;

        
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

        if (previousVerticalAxis < 1 && Math.Abs(verticalAxis - 1) < Mathf.Epsilon)
        {
            print("move up");
            onMoveUp?.Invoke();
        }
        else if (previousVerticalAxis > -1 && Math.Abs(verticalAxis + 1) < Mathf.Epsilon)
        {
            print("Move down");
            onMoveDown?.Invoke();
        }
    }

    public void OnJump()
    {
        if (!acceptInput) return;

        
        jumpButtonPressed = true;
    }

    public void OnJumpRelease()
    {
        if (!acceptInput) return;

        jumpButtonPressed = false;
    }

    public void OnAttack()
    {
        if (!acceptInput) return;

        onAttackButtonPressed?.Invoke();
        attackButtonPressed = true;
    }

    public void OnAttackRelease()
    {
        if (!acceptInput) return;

        attackButtonPressed = false;
    }

    public void OnDash()
    {
        if (!acceptInput) return;

        dashButtonPressed = true;
    }

    public void OnDashRelease()
    {
        if (!acceptInput) return;

        dashButtonPressed = false;
    }

    public void OnSkill1()
    {
        if (!acceptInput) return;

        skill1ButtonPressed = true;
    }

    public void OnSkill1Release()
    {
        if (!acceptInput) return;

        skill1ButtonPressed = false;
    }

    public void OnSkill2()
    {
        if (!acceptInput) return;

        skill2ButtonPressed = true;
    }

    public void OnSkill2Release()
    {
        if (!acceptInput) return;

        skill2ButtonPressed = false;
    }

    public void OnSkill3()
    {
        if (!acceptInput) return;

        skill3ButtonPressed = true;
    }

    public void OnSkill3Release()
    {
        if (!acceptInput) return;

        skill3ButtonPressed = false;
    }

    public void OnSkill4()
    {
        if (!acceptInput) return;

        skill4ButtonPressed = true;
    }

    public void OnSkill4Release()
    {
        if (!acceptInput) return;

        skill4ButtonPressed = false;
    }
    
    


    public override void BindValueToInput()
    {
        
    }
}
