using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateBuffTimer : MonoBehaviour
{
    public float ultimateTimer = 5;
    public float UltimateTimerCounter;
    public bool InUltimateStage => UltimateTimerCounter > 0;

    private Material originalMaterial;

    public event Action onUltimateStart;
    public event Action onUltimateEnd;

    /// <summary>
    /// Change the material system
    /// </summary>
    private void Awake()
    {
        originalMaterial = GetComponent<SpriteRenderer>().material;
    }

    public void Enrage()
    {
        UltimateTimerCounter = ultimateTimer;
        onUltimateStart?.Invoke();
        
    }

    private void Update()
    {
        if (UltimateTimerCounter > 0)
        {
            UltimateTimerCounter -= Time.deltaTime;
            if (UltimateTimerCounter <= 0)
            {
                GetComponent<SpriteRenderer>().material = originalMaterial;
                onUltimateEnd?.Invoke();
            }
        }
    }
}
