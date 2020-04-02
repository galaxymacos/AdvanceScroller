using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FontSizeChanger : MonoBehaviour
{
    public TextMeshProUGUI text;

    public bool AwakeOnStart;
    public UnityEvent onComplete;

    public float endValue = 64;
    public float duration = 3f;

    private bool hasTriggered;

    private void Awake()
    {
        if (text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (AwakeOnStart)
        {
            Trigger();
        }
        // text.DOColor(Color.black, duration);
    }

    private void Trigger()
    {
        if (hasTriggered) return;
        hasTriggered = true;
        text.DOFontSize(endValue, duration).OnComplete(()=>onComplete?.Invoke());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}