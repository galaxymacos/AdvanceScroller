using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Attack Effect/Frozen", fileName = "Frozen")]
public class FrozenEffect: ScriptableObject, IAttackEffect
{
    public float frozenTime;
    // TODO ADD click to stop frozen
}