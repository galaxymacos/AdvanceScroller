using UnityEngine;

public interface IAttackComponent
{
    void Execute();
    void StopDetectTarget();
}
public class ContinuousAttack : CollisionDetector, IAttackComponent
{
    private bool running;
    
    [SerializeField] protected float duration = 3f;
    [SerializeField] protected float tickInterval = 0.2f;
    [SerializeField] protected DamageData damageData;
    
    [SerializeField] protected PlayerCharacter owner;
    private float runTime;
    private float lastTickTime;


    public void Execute()
    {
        running = true;
        Tick();
    }

    public void StopDetectTarget()
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
                runTime += Time.deltaTime;
                if (runTime > duration)
                {
                    StopDetectTarget();
                }
            }
            
            
        }
        
    }


    public virtual void Tick()
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