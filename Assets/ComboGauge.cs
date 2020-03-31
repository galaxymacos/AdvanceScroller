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

    public event Action onComboAdded;

    public event Action onComboBreak;

    private float comboBreakCounter;

    private void Awake()
    {
        // foreach (var singleAttackComponent in GetComponentsInChildren<SingleAttackComponent>())
        // {
        //     singleAttackComponent.onAttackSucceed += AddComboNum;
        // }
        //
        // foreach (var continuousAttack in GetComponentsInChildren<ContinuousAttack>())
        // {
        //     continuousAttack.onContinueAttackSuccess+=AddComboNum;
        // }
        //
        // foreach (var instantKill in GetComponentsInChildren<InstantKillContinuousAttack>())
        // {
        //     instantKill.onContinueAttackSuccess+=AddComboNum;
        // }
    }

    public void BreakComboBecauseOfTakingDamage()
    {
        onComboBreak?.Invoke();
    }

    public void AddComboNum()
    {
        currentComboNum += 1;
        onComboAdded?.Invoke();
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
                onComboBreak?.Invoke();
            }
        }
    }
}
