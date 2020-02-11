using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachineBehavior : StateMachineBehaviour
{
    /// <summary>
    /// Contain all animations in this animator, and whether we can transfer to that state
    /// </summary>
    protected Dictionary<string, bool> animations;
    protected Animator animator;
    protected PlayerInput playerInput;
    public ForceCancelProcessor forceCancelProcessor;
    protected PlayerCharacter playerCharacter;

    // private Knockable knockable;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = _animator;
        playerInput = _animator.GetComponent<PlayerInput>();
        animations = new Dictionary<string, bool>();
        foreach (AnimatorControllerParameter parameter in _animator.parameters)
        {
            animations.Add(parameter.name, false);
        }

        if (forceCancelProcessor)
        {
            RegisterInputToNextState(forceCancelProcessor.animationNameToTransfer);
        }
        playerCharacter = _animator.GetComponent<PlayerCharacter>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        string animationName = InputFilter();
        
        if (forceCancelProcessor)
        {
            animationName = forceCancelProcessor.Process(animationName, _animator);
        }

             
        animationName = LimitUsageFilter(animationName); 
        animationName = CoolDownFilter(animationName);

        if (animationName != "")
        {
            _animator.SetTrigger(animationName);
        }
        
        
        
    }

    public override void OnStateExit(Animator _animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(_animator, stateInfo, layerIndex);
        

    }

    public string LimitUsageFilter(string animationName)
    {
        switch (animationName)
        {
            case "dash":
                if (playerCharacter.dashTimeCounter < playerCharacter.maxDashTimeInAir)
                {
                    return "dash";
                }
                else
                {
                    return "";
                }
        }

        return animationName;
    }

    public void RegisterInputToNextState(List<string> inputs)
    {
        foreach (string input in inputs)
        {
            RegisterInputToNextState(input);
        }
    }

    public string InputFilter()
    {
        foreach (string animationsKey in animations.Keys)
        {
            if (animations[animationsKey])
            {
                switch (animationsKey)
                {
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
                    case "jump":
                        if (playerInput.jumpButtonPressed)
                        {
                            playerInput.jumpButtonPressed = false;
                            return "jump";
                        }

                    

                        break;
                    case "double jump":
                        if (playerInput.jumpButtonPressed)
                        {
                            playerInput.jumpButtonPressed = false;
                            return "double jump";
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

        return "";
    }

    public string CoolDownFilter(string skillName)
    {
        SkillManager playerSkillManager = playerCharacter.GetComponent<SkillManager>();
        if (playerSkillManager.Use(skillName))
        {
            return skillName;
        }

        return "";
    }


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

   
}