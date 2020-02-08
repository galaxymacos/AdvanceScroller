using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachineBehavior : StateMachineBehaviour
{
    /// <summary>
    /// Contain all animations in this animator, and whether we can transfer to that state
    /// </summary>
    private Dictionary<string, bool> animations;
    private Animator animator;
    private PlayerInput playerInput;

    // private Knockable knockable;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        playerInput = animator.GetComponent<PlayerInput>();
        animations = new Dictionary<string, bool>();
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animations.Add(parameter.name, false);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UpdateInput();
    }

    public void RegisterInputToNextState(List<string> inputs)
    {
        foreach (string input in inputs)
        {
            RegisterInputToNextState(input);
        }
    }

    public void UpdateInput()
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
                            animator.SetTrigger("idle");
                        }

                        break;
                    case "run":
                        if (Mathf.Abs(playerInput.horizontalAxis) >= Mathf.Epsilon)
                        {
                            
                            animator.SetTrigger("run");
                        }

                        break;
                    case "jump":
                        if (playerInput.jumpButtonPressed)
                        {
                            playerInput.jumpButtonPressed = false;
                            animator.SetTrigger("jump");
                        }

                    

                        break;
                    case "double jump":
                        if (playerInput.jumpButtonPressed)
                        {
                            playerInput.jumpButtonPressed = false;
                            animator.SetTrigger("double jump");
                        }

                        break;
                    case "dash":
                        if (playerInput.dashButtonPressed)
                        {
                            playerInput.dashButtonPressed = false;
                            animator.SetTrigger("dash");
                        }

                        break;
                    case "attack":
                        if (playerInput.attackButtonPressed)
                        {
                            playerInput.attackButtonPressed = false;
                            animator.SetTrigger("attack");
                        }

                        break;
                    case "skill1":
                        if (playerInput.skill1ButtonPressed)
                        {
                            playerInput.skill1ButtonPressed = false;
                            animator.SetTrigger("skill1");
                        }

                        break;

                    case "skill2":
                        if (playerInput.skill2ButtonPressed)
                        {
                            playerInput.skill2ButtonPressed = false;
                            animator.SetTrigger("skill2");
                        }

                        break;
                    case "skill3":
                        if (playerInput.skill3ButtonPressed)
                        {
                            playerInput.skill3ButtonPressed = false;
                            animator.SetTrigger("skill3");
                        }

                        break;
                    case "skill4":
                        if (playerInput.skill4ButtonPressed)
                        {
                            playerInput.skill4ButtonPressed = false;
                            animator.SetTrigger("skill4");
                        }

                        break;
                    case "jump attack":
                        if (playerInput.attackButtonPressed)
                        {
                            animator.SetTrigger("jump attack");
                        }

                        break;
                }
            }
        }
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