using UnityEngine;

public class HeroineAnimatorController : MonoBehaviour
{
    private Animator animator;
    
    public string attack = "attack";
    public string idle = "idle";
    public string run = "run";
    public string jump = "jump";
    public string jumpAttack = "jump attack";
    public string hurt = "hurt";
    public string fallDown = "fall down";
    public string dash = "dash";
    public string skill1 = "skill1";
    public string skill2 = "skill2";
    public string skill3 = "skill3";
    public string skill4 = "skill4";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    
    public void AnimateIdle()
    {
        Animate(idle);
    }

    public void AnimateDash()
    {
        Animate(dash);
    }

    public void AnimateRun()
    {
        Animate(run);
    }

    public void AnimateJump()
    {
        Animate(jump);
    }

    public void AnimateAttack()
    {
        Animate(attack);
    }
    
    public void AnimateJumpAttack()
    {
        Animate(jumpAttack);
    }
    
    public void AnimateHurt()
    {
        Animate(hurt);
    }

    public void AnimateFalldown()
    {
        Animate(fallDown);
    }

    public void AnimateSkill1()
    {
        Animate(skill1);
    }

    public void AnimateSkill2()
    {
        Animate(skill2);
    }

    public void AnimateSkill3()
    {
        Animate(skill3);
    }

    public void AnimateSkill4()
    {
        Animate(skill4);
    }
    
    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator, boolName);
        animator.SetBool(boolName, true);
    }

    private void DisableOtherAnimations(Animator anim, string animationName)
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            if (parameter.name != animationName)
            {
                anim.SetBool(parameter.name, false);
            }
        }
    }
}