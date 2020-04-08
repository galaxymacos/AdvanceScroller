using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ScaleChanger : MonoBehaviour
{
    public Vector3 endScale;

    public float time;

    public bool awakeOnStart;
    
    public UnityEvent onComplete;

    private bool hasTrigger;
    // Start is called before the first frame update
    void Start()
    {
        if (awakeOnStart)
        {
            
            Trigger();
        }
    }

    public void Trigger()
    {
        if (hasTrigger) return;
        hasTrigger = true;
        transform.DOScale(endScale, time).OnComplete(CallOnComplete);
    }

    private void CallOnComplete()
    {
        onComplete?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
