using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateBuffTimer : MonoBehaviour
{
    public float enrageTimer;
    public float enrageTimerCounter;
    public bool IsEnrage => enrageTimerCounter > 0;

    public void Enrage()
    {
        enrageTimerCounter = enrageTimer;
    }

    private void Update()
    {
        if (enrageTimerCounter > 0)
        {
            enrageTimerCounter -= Time.deltaTime;
        }
    }
}
