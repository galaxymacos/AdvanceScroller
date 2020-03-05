using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCancelShaderControl : MaterialController
{
    public static ForceCancelShaderControl instance;
    [SerializeField] private float shadowLastingTime = 0.1f;

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            print("cannot have more than 1 "+name);
            Destroy(gameObject);
        }
        PlayerCharacterSpawner.onPlayerSpawnFinished += Register;    
    }
    
    public override void Register()
    {
        ForceCancelShadow.onForceCancelshadowCreated += RunBridge;
    }

    public void RunBridge(ForceCancelShadow cancelShadow)
    {
        Run(cancelShadow.sr);
    }
    
    public override MaterialChangeComponent GetShaderComponent(SpriteRenderer sr, Material material)
    {
        return new ForceShadowShaderComponent(sr, material, shadowLastingTime);
    }
}

