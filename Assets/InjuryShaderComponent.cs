using UnityEngine;

public class InjuryShaderComponent: MaterialChangeComponent
{
    private Color materialTintColor = Color.yellow;
    private float tintFadeSpeed = 4f;
    public InjuryShaderComponent(SpriteRenderer renderer, Material material) : base(renderer, material)
    {
        SetMaterialColorToYellow();
    }
    
    public void SetMaterialColorToYellow()
    {
        materialTintColor.a = 1;
        SpriteRenderer.material.SetColor("_Tint", materialTintColor);
    }

    public override void ResetMaterial(Material material)
    {
        SpriteRenderer.material = material;
        SetMaterialColorToYellow();
    }

    public override void Tick()
    {
        if (materialTintColor.a >= 0.01f)
        {
            materialTintColor.a = Mathf.Clamp01(materialTintColor.a - tintFadeSpeed * Time.deltaTime);
            SpriteRenderer.material.SetColor("_Tint",materialTintColor);
        }
    }
}