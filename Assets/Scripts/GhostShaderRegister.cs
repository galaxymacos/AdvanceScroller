using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShaderRegister : MonoBehaviour
{
    private GhostEventSystem ghostEventSystem;
    private ShaderController shaderController;

    private void Awake()
    {
        ghostEventSystem = GetComponent<GhostEventSystem>();
        shaderController = GetComponent<ShaderController>();
        ghostEventSystem.onGhostTakeDamage += EnableDamageShader;
    }

    private void OnDestroy()
    {
        ghostEventSystem.onGhostTakeDamage -= EnableDamageShader;
    }

    private void EnableDamageShader(DamageData damageData)
    {
        shaderController.PlayDamageEffect();
    }

}
