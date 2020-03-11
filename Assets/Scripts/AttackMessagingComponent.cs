using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMessagingComponent : MonoBehaviour
{
    private PlayerCharacter playerCharacter;

    [SerializeField] private SingleAttackComponent singleAttackHitBox;

    [SerializeField] private ContinuousAttack pierceAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>
    public void DetectAttack(int state)
    {
        if (state == 1)
        {
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