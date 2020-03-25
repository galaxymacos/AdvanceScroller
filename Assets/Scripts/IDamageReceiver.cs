using UnityEngine;

public interface IDamageReceiver
{
    void Analyze(DamageData damageData, Transform damageOwner);
}