using UnityEngine;

public class DisolveShadowShaderComponent : MaterialChangeComponent
{
    private float disappearSpeed = 0.5f;
    private float fade = 1f;
    private float delay = 0.5f;
    public DisolveShadowShaderComponent(SpriteRenderer renderer, Material material) : base(renderer, material)
    {
    }

    public override void ResetMaterial(Material material)
    {
        
    }

    public override void Tick()
    {
        if (SpriteRenderer != null)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else
            {
                if (fade > 0)
                {
                    fade -= disappearSpeed * Time.deltaTime;
                    SpriteRenderer.material.SetFloat("_Fade", fade);
                }
                else
                { 
                    Object.Destroy(SpriteRenderer.gameObject);
                }
            }
        }
        
    }
}