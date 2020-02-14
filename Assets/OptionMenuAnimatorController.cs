using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OptionMenuAnimatorController : MonoBehaviour
{
    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void EnableOptionMenu()
    {
        animator.SetTrigger("enable");
    }
}
