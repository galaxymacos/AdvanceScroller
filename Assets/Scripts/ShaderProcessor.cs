using System;
using System.Collections;
using UnityEngine;

public class ShaderProcessor : MonoBehaviour
{
    public Material blurMaterial;
    
    public static ShaderProcessor instance;

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
    }
    
    public void Blur(SpriteRenderer spriteRenderer)
    {
        print("Blurring character");
        spriteRenderer.material = blurMaterial;
        StartCoroutine(BlurCoroutine());
    }

    private IEnumerator BlurCoroutine()
    {
        var currentBlurAmount = blurMaterial.GetFloat("_BlurAmount");
        while (currentBlurAmount < 5)
        {
            currentBlurAmount += 0.08f;
            blurMaterial.SetFloat("_BlurAmount", currentBlurAmount);
            yield return null;
        }

        StartCoroutine(ClearCoroutine());
    }

    private IEnumerator ClearCoroutine()
    {
        var currentBlurAmount = blurMaterial.GetFloat("_BlurAmount");
        while (currentBlurAmount > 0)
        {
            currentBlurAmount -= 0.08f;
            blurMaterial.SetFloat("_BlurAmount", currentBlurAmount);
            yield return null;
        }

        blurMaterial.SetFloat("_BlurAmount", 0);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}