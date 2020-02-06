using System;
using UnityEngine;

public static class UtilityClass{
    public static float GetAnimationLength(Animator animator, string animationName)
    {
        float time = -1f;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        foreach (AnimationClip clip in ac.animationClips)
        {
            if (clip.name == animationName)
            {
                time = clip.length;
            }
        }

        if (time <= 0)
        {
            throw new ArgumentException(animationName+" does not exist in the animator");
        }
        return time;
    }
}