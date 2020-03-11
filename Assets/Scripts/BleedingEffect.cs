using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Attack Effect/Bleeding Effect", fileName = "Bleeding Effect")]
public class BleedingEffect: ScriptableObject, IAttackEffect
{ 
    public float bleedTime;
    public float bleedAmountPerSecond;
}