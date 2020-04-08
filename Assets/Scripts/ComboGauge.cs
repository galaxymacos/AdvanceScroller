using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComboGauge : MonoBehaviour
{
    public int currentComboNum;
    private float timeBeforeComboBreak = 2f;

    public float TimeBeforeComboBreak => timeBeforeComboBreak;

    public event Action<ComboGaugeEventArgs> onComboAdded;

    public event Action<ComboGaugeEventArgs> onComboBreak;

    private float comboBreakCounter;

    public class ComboGaugeEventArgs
    {
        public readonly int comboNum;
        
        public ComboGaugeEventArgs(int comboNum)
        {
            this.comboNum = comboNum;
        }
    }
    public void BreakComboBecauseOfTakingDamage()
    {
        onComboBreak?.Invoke(new ComboGaugeEventArgs(currentComboNum));
    }

    public void AddComboNum()
    {
        currentComboNum += 1;
        onComboAdded?.Invoke(new ComboGaugeEventArgs(currentComboNum));
        comboBreakCounter = timeBeforeComboBreak;
    }

    private void ClearComboNum()
    {
        currentComboNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (comboBreakCounter > 0)
        {
            comboBreakCounter -= Time.deltaTime;
            if (comboBreakCounter <= 0)
            {
                ClearComboNum();
                onComboBreak?.Invoke(new ComboGaugeEventArgs(currentComboNum));
            }
        }
    }
}
