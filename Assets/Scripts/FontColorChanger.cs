using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FontColorChanger : MonoBehaviour
{
    private TextMeshProUGUI text;

    public bool AwakeOnStart;
    public UnityEvent onComplete;

    public Color endValue = Color.black;
    public float duration = 3f;

    private bool hasTriggered;
    
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
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
        if (hasTriggered) return;
        hasTriggered = true;
        text.DOColor(endValue, duration).OnComplete(()=>onComplete?.Invoke());

    }

}