using UnityEngine;

[RequireComponent(typeof(SceneDealDamageComponent))]
public class SnowBallTryHitEnemyComponent : MonoBehaviour
{
    private SceneDealDamageComponent sceneDealDamageComponent;
    private void Awake()
    {
        GetComponent<SmallSnowballEventSystem>().onSmallSnowballTakeDamage += Setup;
        sceneDealDamageComponent = GetComponent<SceneDealDamageComponent>();

    }

    private void Setup(SnowballDamageReceiver.DamageReceiverArgs damageReceiverArgs)
    {
        sceneDealDamageComponent.SetOwner(damageReceiverArgs.damageOwner.GetComponent<PlayerCharacter>());
        sceneDealDamageComponent.SetActive(true);
    }

}