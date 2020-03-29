using System;
using UnityEngine;

public class CharacterShaderRegister : MonoBehaviour
{
    private ShaderController shaderController;


    private void Awake()
    {
        shaderController = GetComponent<ShaderController>();
        
        GetComponent<CharacterHealthComponent>().onTakeHit += BridgeToTriggerDamageEffectShader;
        GetComponent<PlayerCharacter>().onDashOutFromHurt += shaderController.AttackMissEffect;

        if (GetComponent<UltimateBuffTimer>() != null)
        {
            GetComponent<UltimateBuffTimer>().onUltimateStart += shaderController.EnableOutline;
            GetComponent<UltimateBuffTimer>().onUltimateEnd += shaderController.DisableOutline;

        }
    }

    private void OnDestroy()
    {
        GetComponent<CharacterHealthComponent>().onTakeHit -= BridgeToTriggerDamageEffectShader;
        GetComponent<PlayerCharacter>().onDashOutFromHurt -= shaderController.AttackMissEffect;
        if (GetComponent<UltimateBuffTimer>() != null)
        {
            GetComponent<UltimateBuffTimer>().onUltimateStart -= shaderController.EnableOutline;
            GetComponent<UltimateBuffTimer>().onUltimateEnd -= shaderController.DisableOutline;

        }
    }


    private void BridgeToTriggerDamageEffectShader(CharacterHealthComponent characterHealthComponent)
    {
        shaderController.PlayDamageEffect();
    }
    
}