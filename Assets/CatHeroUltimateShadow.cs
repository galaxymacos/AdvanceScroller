using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHeroUltimateShadow : MonoBehaviour
{
    private ShadowSpritesStorer shadowSpritesStorer;
    private static int orderInIndex = -1;
    private SpriteRenderer sr;
    private bool hasSetup;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = orderInIndex--;
    }

    public void Setup(ShadowSpritesStorer other)
    {
        
        if (hasSetup) return;
        hasSetup = true;
        shadowSpritesStorer = other;
    }

    private void Update()
    {
        if (hasSetup && shadowSpritesStorer.TwosecsAgo!=null)
        {
            sr.sprite = shadowSpritesStorer.TwosecsAgo.sprite;
            // transform.Translate();
            transform.position = shadowSpritesStorer.TwosecsAgo.historyPosition;
            transform.localScale = shadowSpritesStorer.TwosecsAgo.historyScale;
            transform.rotation = shadowSpritesStorer.TwosecsAgo.historyRotation;
        }
    }

    public void Dispose()
    {
        StartCoroutine(Disposing());
    }

    private IEnumerator Disposing()
    {
        Material mat = sr.material;
        while (mat.GetFloat("_TwistUvAmount") < 0.15||mat.GetFloat("_Alpha")>0)
        {
            mat.SetFloat("_TwistUvAmount", 1.5f * Time.deltaTime + mat.GetFloat("_TwistUvAmount"));
            mat.SetFloat("_Alpha", mat.GetFloat("_Alpha")-1f * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
