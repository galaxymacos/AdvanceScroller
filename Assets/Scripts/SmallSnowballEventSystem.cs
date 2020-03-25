using System;
using UnityEngine;

public class SmallSnowballEventSystem : MonoBehaviour
{
    public event Action<SnowballDamageReceiver.DamageReceiverArgs> onSmallSnowballTakeDamage;

}