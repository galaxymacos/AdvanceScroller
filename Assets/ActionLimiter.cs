using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLimiter : MonoBehaviour
{
    public List<string> animations;
    
    private Dictionary<string, List<Func<bool>>> animationLimiters;

    private void Awake()
    {
        animationLimiters = new Dictionary<string, List<Func<bool>>>();
        Init(animations);
    }

    private void Init(List<string> animationName)
    {
        foreach (string s in animationName)
        {
            animationLimiters.Add(s, new List<Func<bool>>());
        }
    }
    
    public void AddLimiterToAnimation(string _animation, Func<bool> condition )
    {
        if (animationLimiters == null) Init(animations);
        if (animationLimiters.ContainsKey(_animation))
        {
            animationLimiters[_animation].Add(condition);
        }
        else
        {
            Debug.LogError("doesn't contain animation with the name of "+_animation);
        }
    }

    public bool CanGoToAnimation(string _animation)
    {
        if (animationLimiters.ContainsKey(_animation))
        {
            var limiters = animationLimiters[_animation];
            foreach (var condition in limiters)
            {
                var result = condition();
                if (result == false)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
