using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditIdleLimiter : MonoBehaviour
{
    public BanditData banditData;
    public ActionLimiter actionLimiter;

    private void Start()
    {
        actionLimiter.AddLimiterToAnimation("Idle", AnxiousToJump);
    }

    private bool AnxiousToJump()
    {
        return banditData.targetPlayer != null;
    }

}
