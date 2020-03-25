using System;
using UnityEngine;

public class SnowballEventSystem : MonoBehaviour
{
    public event Action<SnowballDamageReceiver.DamageReceiverArgs> onSnowballTakeDamage;
    public event Action onSnowballReset;

    public void SnowballTakeDamage(SnowballDamageReceiver.DamageReceiverArgs args)
    {
        onSnowballTakeDamage?.Invoke(args);
    }

    public void SnowballReset()
    {
        onSnowballReset?.Invoke();
    }
    
    
}