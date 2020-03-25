using UnityEngine;

[RequireComponent(typeof(SceneDealDamageComponent))]
public class SnowBallTryHitEnemyComponent : MonoBehaviour
{
    private SceneDealDamageComponent sceneDealDamageComponent;
    private void Awake()
    {
        GetComponent<SnowballEventSystem>().onSnowballTakeDamage += Setup;
        GetComponent<SnowballEventSystem>().onSnowballReset += Reset;
        sceneDealDamageComponent = GetComponent<SceneDealDamageComponent>();
    }

    private void Setup(SnowballDamageReceiver.DamageReceiverArgs damageReceiverArgs)
    {
        sceneDealDamageComponent.SetOwner(damageReceiverArgs.damageOwner.GetComponent<PlayerCharacter>());
        sceneDealDamageComponent.SetActive(true);
    }

    private void Reset()
    {
        sceneDealDamageComponent.SetOwner(null);
        sceneDealDamageComponent.SetActive(false);
    }
    
    

}