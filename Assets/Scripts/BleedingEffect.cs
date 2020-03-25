using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Attack Effect/Bleeding", fileName = "Bleeding")]
public class BleedingEffect: ScriptableObject, IAttackEffect
{ 
    public float bleedTime;
    public float bleedAmountPerSecond;
}