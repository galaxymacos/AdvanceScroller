using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAttackLimiter : MonoBehaviour
{
    public BanditData banditData;
    public ActionLimiter actionLimiter;

    private void Start()
    {
        actionLimiter.AddLimiterToAnimation("Attack", AttackCooldownCondition);
    }

    private bool AttackCooldownCondition()
    {
        return Time.time >= banditData.attackCooldown + banditData.lastAttackTime;
    }
    
    
}
