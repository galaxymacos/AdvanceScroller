using System;
using UnityEngine;

public class DissolveShadowCreationMessager : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer sr;
    public static Action<DissolveShadowCreationMessager> onDissolveShadowCreated;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        onDissolveShadowCreated?.Invoke(this);
    }


    public void Setup(SpriteRenderer spriteCopyToShadow)
    {
        transform.localScale = spriteCopyToShadow.transform.localScale;
        GetComponent<SpriteRenderer>().sprite = spriteCopyToShadow.sprite;
    }
}