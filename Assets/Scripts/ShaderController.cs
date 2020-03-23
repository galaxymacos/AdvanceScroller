﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController : MonoBehaviour
{
    private Material mat;
    private float growDecreaseSpeed = 50;
    private float ChromaticAbberationFadeSpeed = 0.4f;
    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }
    
    

    public void EnableOutline()
    {
        mat.SetFloat("_OutlineAlpha", 1.0f);
    }

    public void DisableOutline()
    {
        mat.SetFloat("_OutlineAlpha", 0f);
    } 

    public void PlayDamageEffect()
    {
        mat.SetFloat("_Glow", 13f);


        StartCoroutine(StopDamageEffect());
    }

    private IEnumerator StopDamageEffect()
    {
        while (mat.GetFloat("_Glow") > 0f)
        {
            mat.SetFloat("_Glow", Math.Max(0, mat.GetFloat("_Glow") - growDecreaseSpeed * Time.deltaTime));
            yield return null;
        }
    }

    public void AttackMissEffect()
    {
        mat.SetFloat("_ChromAberrAmount", 1);
        StartCoroutine(RecoverFromAttackEffect());

    }

    private IEnumerator RecoverFromAttackEffect()
    {
        while (mat.GetFloat("_ChromAberrAmount") >= 0)
        {
            mat.SetFloat("_ChromAberrAmount", Mathf.Max(0,mat.GetFloat("_ChromAberrAmount")-ChromaticAbberationFadeSpeed*Time.deltaTime));
            print("chronmatic fade");
            yield return null;
        }
    }

    public void SkillOnCooldownEffect()
    {
        mat.SetFloat("_ShakeUvSpeed", 4);
        StartCoroutine(RecoverFromShake());
    }

    private IEnumerator RecoverFromShake()
    {
        yield return new WaitForSeconds(0.2f);
        mat.SetFloat("_ShakeUvSpeed", 0);
    }
    
    
}