using System;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackComponent
{
    void Execute();
    void Stop();
}
public class ContinuousAttack : CollisionDetector, IAttackComponent
{
    private bool running;
    
    [SerializeField] private float duration = 5f;
    [SerializeField] private float tickInterval = 0.2f;
    [SerializeField] private DamageData damageData;
    
    [SerializeField] private PlayerCharacter owner;
    private float runTime;
    private float lastTickTime;


    public void Execute()
    {
        running = true;
        Tick();
    }

    public void Stop()
    {
        running = false;
        runTime = 0;
        lastTickTime = 0;

    }
    
    private void Update()
    {
        if (running)
        {
            if (runTime > lastTickTime + tickInterval)
            {
                Tick();
                lastTickTime = runTime;
            }
            
            if (duration > 0)
            {
                StopIfTimeOver();
            }
            
            
        }
        
    }

    private void StopIfTimeOver()
    {
        runTime += Time.deltaTime;
        if (runTime > duration)
        {
            Stop();
        }
    }


    public void Tick()
    {
        foreach (GameObject target in objectsInCollision)
        {
            if (target == null || target == owner.gameObject) continue;
            var damageReceiver = target.GetComponent<DamageReceiver>();
            if (damageReceiver != null)
            {
                damageReceiver.Analyze(damageData, transform.root);
            }
            
        }
    }
    
    
}