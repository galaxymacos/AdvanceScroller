using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateBuffTimer : MonoBehaviour
{
    public float enrageTimer;
    public float enrageTimerCounter;
    public bool IsEnrage => enrageTimerCounter > 0;

    private Material originalMaterial;

    public event Action onEnrageStart;
    public event Action onEnrageEnd;

    /// <summary>
    /// Change the material system
    /// </summary>
    private void Awake()
    {
        originalMaterial = GetComponent<SpriteRenderer>().material;
    }

    public void Enrage()
    {
        enrageTimerCounter = enrageTimer;
        onEnrageStart?.Invoke();
        
    }

    private void Update()
    {
        if (enrageTimerCounter > 0)
        {
            enrageTimerCounter -= Time.deltaTime;
            if (enrageTimerCounter <= 0)
            {
                GetComponent<SpriteRenderer>().material = originalMaterial;
                onEnrageEnd?.Invoke();
            }
        }
    }
}
