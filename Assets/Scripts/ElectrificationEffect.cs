using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Attack Effect/Electrification Effect", fileName = "Electrification Effect")]
public class ElectrificationEffect : ScriptableObject, IAttackEffect
{
    public float duration = 3f;
    public float ElectrificationOdd = 0.5f;
    public float damagePerTick = 7f;
}