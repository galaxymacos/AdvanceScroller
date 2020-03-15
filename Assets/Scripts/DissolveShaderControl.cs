using UnityEngine;

public class DissolveShaderControl : MaterialController
{
    public static DissolveShaderControl instance;
    public float disappearSpeed = 0.5f;
    private float fade = 1f;
    public float delay = 0.5f;
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
        DissolveShadowCreationMessager.onDissolveShadowCreated += RunBridge;
    }

    public void RunBridge(DissolveShadowCreationMessager dissolveShadowCreationMessager)
    {
        Run(dissolveShadowCreationMessager.sr);
    }
    
    public override MaterialChangeComponent GetShaderComponent(SpriteRenderer sr, Material material)
    {
        return new DisolveShadowShaderComponent(sr, material);   
    }
    
}