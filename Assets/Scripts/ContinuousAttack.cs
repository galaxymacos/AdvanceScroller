using System;
using UnityEngine;

public interface IAttackComponent
{
    bool Execute();
}
public class ContinuousAttack : CollisionDetector, IAttackComponent
{
    private bool running;
    
    [Tooltip("The length of time that the duration skill will last if not stopping manually")]
    [SerializeField] protected float duration = 3f;
    [SerializeField] protected float tickInterval = 0.2f;
    [SerializeField] protected DamageData damageData;
    [SerializeField] protected DamageData finalDamageData;
    

    [SerializeField] protected PlayerCharacter owner;
    private float runTime;
    private float lastTickTime;

    public Action oneLastStrikeFinished;

    public bool hasUsedOneLastStrike;


    public bool Execute()
    {
        hasUsedOneLastStrike = false;
        running = true;
        Tick();

        return false;    // TODO add the logic for continous attack to return if it hits the enemy or not
    }

    public void StopDetectTargetManually()
    {
        StopDetectTarget();
    }

    private void StopDetectTargetWhenDurationEnd()
    {
        StopDetectTarget();
    }

    private void StopDetectTarget()
    {
        running = false;
        runTime = 0;
        lastTickTime = 0;
        if (!hasUsedOneLastStrike)
        {
            OneLastStrike();
            hasUsedOneLastStrike = true;
        }
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
                runTime += Time.deltaTime;
                if (runTime > duration)
                {
                    StopDetectTargetWhenDurationEnd();
                }
            }
            
            
        }
        
    }

    public virtual void OneLastStrike()
    {
        oneLastStrikeFinished?.Invoke();
        if (finalDamageData == null) return;

        foreach (GameObject target in ObjectsInCollision)
        {
            if (target == null || target == owner.gameObject) continue;
            var damageReceiver = target.GetComponent<IDamageReceiver>();
            if (damageReceiver != null)
            {
                print("one last strike");
                damageReceiver.Analyze(finalDamageData, transform.root);
            }
            
        }
    }


    public virtual void Tick()
    {
        foreach (GameObject target in ObjectsInCollision)
        {
            if (target == null || target == owner.gameObject) continue;
            
            var damageReceiver = target.GetComponent<IDamageReceiver>();
            damageReceiver?.Analyze(damageData, transform.root);

        }
    }
    
    
}