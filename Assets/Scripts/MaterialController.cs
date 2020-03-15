using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MaterialController:MonoBehaviour
{
    
    [SerializeField] protected Material material;
    protected SpriteRenderer _sr;

    protected List<MaterialChangeComponent> MaterialShaderComponents = new List<MaterialChangeComponent>();


    

    /// <summary>
    /// Decide when should we activate this shader
    /// </summary>
    public abstract void Register();
    
    public void Run(SpriteRenderer sr)
    {
    
        bool hasInitialized = false;
        foreach (MaterialChangeComponent component in MaterialShaderComponents)
        {
            if (component.SpriteRenderer == sr)
            {
                hasInitialized = true;
                component.ResetMaterial(material);
            }
        }

        if (!hasInitialized)
        {
            MaterialChangeComponent materialChangeComponent = GetShaderComponent(sr, material);
            MaterialShaderComponents.Add(materialChangeComponent);
        }
    }

    public abstract MaterialChangeComponent GetShaderComponent(SpriteRenderer sr, Material material);

    public virtual void Update()
    {
        foreach (MaterialChangeComponent materialChangeComponent in MaterialShaderComponents)
        {
            materialChangeComponent.Tick();
        }
    }
}

