using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InjuryMaterialController : MaterialController
{
    public static InjuryMaterialController instance;
    private List<InjuryComponent> injuryComponents = new List<InjuryComponent>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerCharacterSpawner.onPlayerSpawnFinished += Register;    
    }
    public void Register()
    {
        IEnumerable<CharacterHealthComponent> healthComponent = FindObjectsOfType<MonoBehaviour>().OfType<CharacterHealthComponent>();
        foreach (CharacterHealthComponent characterHealthComponent in healthComponent)
        {
            characterHealthComponent.onTakeDamage += RunBridge;
        }
    }

    private void RunBridge(CharacterHealthComponent characterHealthComponent)
    {
        Run(characterHealthComponent.GetComponent<SpriteRenderer>());
    }



    public override void Run(SpriteRenderer sr)
    {
        bool hasInitialized = false;
        foreach (InjuryComponent component in injuryComponents)
        {
            if (component.SpriteRenderer == sr)
            {
                hasInitialized = true;
                component.ResetMaterial(material);
                component.SetMaterialColorToYellow();
            }
        }

        if (!hasInitialized)
        {
            InjuryComponent injuryComponent = new InjuryComponent(sr, material);
            injuryComponents.Add(injuryComponent);
        }
    }
    private void Update()
    {

        foreach (InjuryComponent injuryComponent in injuryComponents)
        {
            injuryComponent.Tick();
        }
    }
}

public class InjuryComponent
{
    public SpriteRenderer SpriteRenderer;
    private Color materialTintColor = Color.yellow;
    private float tintFadeSpeed = 4f;
    public InjuryComponent(SpriteRenderer renderer, Material material)
    {
        SpriteRenderer = renderer;
        
        ResetMaterial(material);
        SetMaterialColorToYellow();
    }

    public void ResetMaterial(Material material)
    {
        SpriteRenderer.material = material;
    }

    public void Tick()
    {
        if (materialTintColor.a >= 0.01f)
        {
            materialTintColor.a = Mathf.Clamp01(materialTintColor.a - tintFadeSpeed * Time.deltaTime);
            SpriteRenderer.material.SetColor("_Tint",materialTintColor);
        }
        
    }

    public void SetMaterialColorToYellow()
    {
        materialTintColor.a = 1;
        SpriteRenderer.material.SetColor("_Tint", materialTintColor);
    }
}