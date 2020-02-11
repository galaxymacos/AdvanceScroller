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
    [SerializeField] private int damagePerTick = 3;

    [SerializeField]private bool canHitStun;
    [SerializeField] private float hitStunTime;
    
    [SerializeField] private PlayerCharacter owner;
    private float runTime;
    private float lastTickTime;


    public void Execute()
    {
        running = true;
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
            runTime+=Time.deltaTime;
            if (runTime > duration)
            {
                Stop();
            }
            if (runTime > lastTickTime + tickInterval)
            {
                Tick();
                lastTickTime = runTime;
            }
        }
        
    }



    public void Tick()
    {
        foreach (GameObject target in objectsInCollision)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null && target != owner.gameObject)
            {
                healthComponent.TakeDamage(damagePerTick, true);
            }

            if (canHitStun)
            {
                StunComponent stunComponent = target.GetComponent<StunComponent>();
                if (stunComponent != null && target != owner.gameObject)
                {
                    stunComponent.SetStunTime(hitStunTime);
                }
            }
            
        }
    }
    
    
}