using System;
using UnityEngine;

public abstract class RandomEvent: MonoBehaviour
{
    public float spawnEventInterval = 2f;
    private float spawnEventCounter;
    private void Start()
    {
        spawnEventCounter = spawnEventInterval;
    }

    protected virtual void Update()
    {
        if (GameStateMachine.gameIsPause) return;
        
        
        if (spawnEventCounter > 0)
        {
            spawnEventCounter -= Time.deltaTime;
            if (spawnEventCounter <= 0)
            {
                Execute();
                spawnEventCounter = spawnEventInterval;
            }
        }
    }

    public abstract void Execute();
    public void UnPause()
    {
        throw new NotImplementedException();
    }
}