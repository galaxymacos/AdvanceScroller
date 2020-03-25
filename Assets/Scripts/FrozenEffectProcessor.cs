using UnityEngine;

public class FrozenEffectProcessor : MonoBehaviour, IAttackEffectProcessor
{
    private float frozenTime;

    public float FrozenTime => frozenTime;
    public bool IsFrozen => FrozenTime > 0;

    private static readonly int Frozen = Animator.StringToHash("frozen");

    public void Process(DamageData damageData)
    {
        if (damageData.attackEffects == null) return;
        foreach (ScriptableObject attackEffect in damageData.attackEffects)
        {
            var frozenEffect = attackEffect as FrozenEffect;
            if (frozenEffect != null)
            {
                frozenTime = frozenEffect.frozenTime;
                GetComponentInParent<Animator>().SetTrigger(Frozen);
            }
        }
    }
    
    
}