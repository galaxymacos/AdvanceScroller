using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MaterialTintColor : MonoBehaviour
{
    public Material tintMaterial;
    private Material material;
    private Color materialTintColor;
    private float tintFadeSpeed;

    private void Awake()
    {
        PlayerCharacterSpawner.onPlayerSpawnFinished += Register;
    }

    public void Register()
    {
        IEnumerable<CharacterHealthComponent> healthComponent = FindObjectsOfType<MonoBehaviour>().OfType<CharacterHealthComponent>();
        foreach (CharacterHealthComponent characterHealthComponent in healthComponent)
        {
            characterHealthComponent.onTakeDamage += StartFlashing;
        }

    }

    public void StartFlashing(CharacterHealthComponent healthComponent)
    {
        materialTintColor = Color.yellow;
        healthComponent.GetComponent<SpriteRenderer>().material = tintMaterial;
        SetMaterial(healthComponent.GetComponent<SpriteRenderer>().material);
        tintFadeSpeed = 4f;
    }

    private void Update()
    {
        if (materialTintColor.a > 0)
        {
            materialTintColor.a = Mathf.Clamp01(materialTintColor.a - tintFadeSpeed * Time.deltaTime);
            material.SetColor("_Tint",materialTintColor);
            
        }
    }

    public void SetMaterial(Material material)
    {
        this.material = material;
    }

    public void SetTintColor(Color color)
    {
        materialTintColor = color;
        material.SetColor("_Tint", materialTintColor);
    }
}