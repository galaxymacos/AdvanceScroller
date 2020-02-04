using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private const string IDLE_ANIMATION_BOOL = "idle";
    private const string DEATH_ANIMATION_BOOL = "death";
    private const string JUMP_ANIMATION_BOOL = "jump";
    private const string RUN_ANIMATION_BOOL = "run";
    private const string ATTACK_ANIMATION_BOOL = "attack";
    private const string DOUBLEJUMP_ANIMATION_BOOL = "double jump";

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }

    public void AnimateDie()
    {
        Animate(DEATH_ANIMATION_BOOL);
    }

    public void AnimateAttack()
    {
        Animate(ATTACK_ANIMATION_BOOL);
    }

    public void AnimateMove()
    {
        Animate(RUN_ANIMATION_BOOL);
    }

    public void AnimateJump()
    {
        print("animate jump");
        Animate(JUMP_ANIMATION_BOOL);
    }
    
    public void AnimateDoubleJump()
    {
        Animate(DOUBLEJUMP_ANIMATION_BOOL);
    }

    
    

    private void Animate(string boolName)
    {
        DisableotherAnimations(animator, boolName);
        animator.SetBool(boolName, true);
    }

    private void DisableotherAnimations(Animator animator, string animation)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    } 
    
    
}