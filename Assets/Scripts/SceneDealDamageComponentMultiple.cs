using UnityEngine;

[RequireComponent(typeof(CollisionDetector))]
public class SceneDealDamageComponentMultiple : MonoBehaviour
{
    public CollisionDetector collisionDetector;
    public DamageData damageDataPerTick;
    public float tickInterval = 0.2f;
    public float tickIntervalCounter;
    
    private void Awake()
    {
        tickIntervalCounter = tickInterval;
    }

    private void Update()
    {
        if (tickIntervalCounter > 0)
        {
            tickIntervalCounter -= Time.deltaTime;
            if (tickIntervalCounter <= 0)
            {
                tickIntervalCounter = tickInterval;
                DealDamagePerTick();
            }
        }
        
       
    }

    private void DealDamagePerTick()
    {
        foreach (var objInCollision in collisionDetector.ObjectsInCollision)
        {
            var healthComponent = objInCollision.GetComponent<IDamageReceiver>();
            healthComponent?.Analyze(damageDataPerTick,transform);
        }
    }
}