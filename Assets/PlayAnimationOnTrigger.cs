using System.Collections;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayAnimationOnTrigger : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Trigger()
    {
        // anim.DOPlay();
        // anim.DOPlayForward();

        // animation.Play("Play Clot");
        // StopAllCoroutines();
        anim.SetTrigger("Play");

        // StartCoroutine(ActiveDeactiveAnimator());
    }

    public void Trigger(string animationName)
    {
        anim.SetTrigger(animationName);
    }

    public void TriggerReverse()
    {
        anim.SetTrigger("Reverse");
    }

}
