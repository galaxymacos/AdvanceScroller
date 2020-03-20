using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPrincessAttackMessagingComponent : MonoBehaviour
{
    [SerializeField] private SingleAttackComponent singleAttackHitBox;

    [SerializeField] private ContinuousAttack pierceAttack;

    private UltimateBuffTimer ultimateBuffTimer;
    public static event Action onBuffedAttack;

    private void Awake()
    {
        ultimateBuffTimer = GetComponent<UltimateBuffTimer>();
    }

    public void DetectAttack(int state)
    {
        if (state == 1)
        {
            if (ultimateBuffTimer.IsEnrage)
            {
                onBuffedAttack?.Invoke();
            }
            singleAttackHitBox.Execute();
            
        }
        
    }

    public void DetectPierceAttack(int state)
    {
        if (state == 1)
        {
            pierceAttack.Execute();
        }
        else if (state == 0)
        {
            pierceAttack.StopDetectTargetManually();
        }

    }
}