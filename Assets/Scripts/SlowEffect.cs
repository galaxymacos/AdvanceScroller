using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Attack Effect/Slow", fileName = "Slow")]
public class SlowEffect: ScriptableObject, IAttackEffect
{ 
    [Range(0,1)]
    public float slowPercent;
    [Range(0,20)]
    public float slowDuration;

}