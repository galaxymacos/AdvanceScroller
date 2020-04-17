﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachineBehavior : StateMachineBehaviour
{
    protected Rigidbody2D rb;
    public List<string> stateCanTransformTo;
    public List<string> stateCanForceTransformTo;
    public string soundInString;
    [SerializeField] private bool canControlHorizontalMovement;
    [SerializeField] private bool canFloatInAir;
    [SerializeField] private bool IsRecoverState;
    protected bool isPaused;
    private Vector3 velocityBeforePause;
    private float timeInCurrentState;
    private float timeOfCurrentState;

    /// <summary>
    /// Contain all animations in this animator, and whether we can transfer to that state
    /// </summary>
    private Dictionary<string, bool> animations;

    [HideInInspector] public Animator characterAnimator;
    protected PlayerInput playerInput => playerCharacter.playerInput;
    [HideInInspector] public PlayerCharacter playerCharacter;


    // private Knockable knockable;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeOfCurrentState = _animator.GetCurrentAnimatorStateInfo(0).length;
        timeInCurrentState = 0;
        characterAnimator = _animator;
        animations = new Dictionary<string, bool>();
        foreach (AnimatorControllerParameter parameter in _animator.parameters)
        {
            animations.Add(parameter.name, false);
        }

        playerCharacter = _animator.GetComponent<PlayerCharacter>();
        playerCharacter.canControlMovement = canControlHorizontalMovement;
        RegisterInputToNextState(stateCanTransformTo);
        RegisterInputToNextState(stateCanForceTransformTo);
        if (!string.IsNullOrEmpty(soundInString))
        {
            AudioController.instance.PlayAudio(soundInString.GetAudioType());
        }

        rb = _animator.GetComponent<Rigidbody2D>();
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Mathf.Abs(playerInput.horizontalAxis) >= Mathf.Epsilon)
        {
            Debug.Log("still detecting player input");
        }
        if (GameStateMachine.gameIsPause) return;

        if (IsRecoverState && timeInCurrentState < timeOfCurrentState)
        {
            timeInCurrentState+=Time.deltaTime;
            if (timeInCurrentState >= timeOfCurrentState-0.02f)
            {
                    if (!playerCharacter.IsGrounded)
                    {
                        _animator.SetTrigger("fall down");
                    }
                    else
                    {
                        _animator.SetTrigger("idle");
                    }
            }
        }

        
        string animationName = GenerateAnimationByInput();
        
        if (animationName != "")
        {
            var cooldownFilter = new CooldownFilter(animationName, this, null);
            var ultimateRageFilter = new UltimateRageFilter(animationName, this, cooldownFilter);
            var forceAttackFilter = new ForceAttackFilter(animationName, this, ultimateRageFilter);
            var limitedUsageFilter = new LimitedUsageFilter(animationName, this, forceAttackFilter);


            if (limitedUsageFilter.FilterRecur())
            {
                limitedUsageFilter.DealWithResultRecur();
                _animator.SetTrigger(animationName);
            }
        }
    }


    public override void OnStateExit(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(_animator, stateInfo, layerIndex);
        
    }

    protected void RegisterInputToNextState(List<string> inputs)
    {
        foreach (string input in inputs)
        {
            RegisterInputToNextState(input);
        }
    }

    private string GenerateAnimationByInput()
    {
        if (playerCharacter.playerInput == null) return "";
        

        foreach (string animationsKey in animations.Keys)
        {
            if (animations[animationsKey])
            {
                switch (animationsKey)
                {
                    case "jump":
                        if (playerInput.jumpButtonPressed)
                        {
                            playerInput.jumpButtonPressed = false;
                            return "jump";
                        }

                        break;
                    case "dash":
                        if (playerInput.dashButtonPressed)
                        {
                            playerInput.dashButtonPressed = false;
                            return "dash";
                        }

                        break;
                    case "attack":
                        if (playerInput.attackButtonPressed)
                        {
                            playerInput.attackButtonPressed = false;
                            return "attack";
                        }

                        break;
                    case "skill1":
                        if (playerInput.skill1ButtonPressed)
                        {
                            playerInput.skill1ButtonPressed = false;
                            return "skill1";
                        }

                        break;

                    case "skill2":
                        if (playerInput.skill2ButtonPressed)
                        {
                            playerInput.skill2ButtonPressed = false;
                            return "skill2";
                        }

                        break;
                    case "skill3":
                        if (playerInput.skill3ButtonPressed)
                        {
                            playerInput.skill3ButtonPressed = false;
                            return "skill3";
                        }

                        break;
                    case "skill4":
                        if (playerInput.skill4ButtonPressed)
                        {
                            playerInput.skill4ButtonPressed = false;
                            return "skill4";
                        }

                        break;


                    case "jump attack":
                        if (playerInput.attackButtonPressed)
                        {
                            return "jump attack";
                        }

                        break;
                }
            }
        }
        
        foreach (string animationsKey in animations.Keys)
        {
            if (animations[animationsKey])
            {
                switch (animationsKey)
                {
                    

                    case "acquire":
                        if (playerInput.verticalAxis < 0)
                        {
                            return "acquire";
                        }

                        break;
                    case "climb":
                        if (playerInput.verticalAxis > 0)
                        {
                            return "climb";
                        }

                        break;
                    case "stomp":
                        if (playerInput.verticalAxis < 0)
                        {
                            return "stomp";
                        }

                        break;
                    case "idle":
                        if (Mathf.Abs(playerInput.horizontalAxis) < Mathf.Epsilon)
                        {
                            return "idle";
                        }

                        break;
                    case "run":
                        if (Mathf.Abs(playerInput.horizontalAxis) >= Mathf.Epsilon)
                        {
                            return "run";
                        }

                        break;
                }
            }
        }

        return "";
    }

    // public string CoolDownFilter(string skillName)
    // {
    //     SkillCooldownManager playerSkillCooldownManager = playerCharacter.GetComponent<SkillCooldownManager>();
    //     if (playerSkillCooldownManager.Use(skillName))
    //     {
    //         return skillName;
    //     }
    //
    //     return "";
    // }


    public void RegisterInputToNextState(string input)
    {
        if (animations.ContainsKey(input))
        {
            animations[input] = true;
        }
    }

    public void DeregisterInput(List<string> inputs)
    {
        foreach (string input in inputs)
        {
            if (animations.ContainsKey(input))
            {
                animations[input] = false;
            }
        }
    }

    public void DeregisterInput(string input)
    {
        if (animations.ContainsKey(input))
        {
            animations[input] = false;
        }
    }

    protected void TransferToWallSlide()
    {
        characterAnimator.SetTrigger("wallslide");
    }

    
}