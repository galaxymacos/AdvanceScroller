using UnityEngine;

public abstract class MaterialChangeComponent
{
    public SpriteRenderer SpriteRenderer;
    private Color materialTintColor = Color.yellow;
    private float tintFadeSpeed = 4f;
    public MaterialChangeComponent(SpriteRenderer renderer, Material material)
    {
        SpriteRenderer = renderer;
        ResetMaterial(material);
    }

    public abstract void ResetMaterial(Material material);

    public abstract void Tick();

    public void SetMaterialColorToYellow()
    {
        materialTintColor.a = 1;
        SpriteRenderer.material.SetColor("_Tint", materialTintColor);
    }
}