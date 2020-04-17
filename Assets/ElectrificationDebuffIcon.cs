using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class ElectrificationDebuffIcon : MonoBehaviour
{
    private PlayerPanel playerPanel;
    private Image sr;
    private float durationCounter;
    private bool hasSetuped;

    private void Awake()
    {
        sr = GetComponent<Image>();
        sr.enabled = false;
    }

    public void Show(object sender, BuffEventArgs eventArgs)
    {
        durationCounter = eventArgs.duration;
        sr.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (durationCounter > 0)
        {
            print("bleed duration: "+durationCounter);
            durationCounter -= Time.deltaTime;
            if (durationCounter <= 0)
            {
                sr.enabled = false;
            }
        }
    }
}

[Serializable]
public class BuffUnityEvent : UnityEvent<object,BuffEventArgs>
{
    
}