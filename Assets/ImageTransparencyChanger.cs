using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageTransparencyChanger : MonoBehaviour
{
    private Image image;
    public bool AwakeOnStart;
    public UnityEvent onComplete;

    public float endValue;
    public float duration = 3f;

    private bool hasTriggered;
    
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (AwakeOnStart)
        {
            Trigger();
        }
    }

    public void Trigger()
    {
        if (hasTriggered) return;
        hasTriggered = true;
        print("Fading");
        image.DOFade(endValue, duration).OnComplete(()=>onComplete?.Invoke());

    }
}
