using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FontPingPongEffect : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float originalFontSize;

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

        originalFontSize = text.fontSize;
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

    public void Trigger()
    {
        text.DOFontSize(endValue, duration/2).OnComplete(Recover);
    }

    private void Recover()
    {
        text.DOFontSize(originalFontSize, duration/2).OnComplete(()=>onComplete?.Invoke());
    }

    public void ForceRecover()
    {
        text.fontSize = originalFontSize;
    }
    
}