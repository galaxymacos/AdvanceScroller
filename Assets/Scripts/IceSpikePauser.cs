using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikePauser : MonoBehaviour , IPauseable
{
    private IceSpike iceSpike;
    private float speedBeforePause;

    private void Awake()
    {
        iceSpike = GetComponent<IceSpike>();
        speedBeforePause = iceSpike.speed;
    }

    public void Pause()
    {
        iceSpike.speed = 0;
    }

    public void UnPause()
    {
        iceSpike.speed = speedBeforePause;
    }

}
