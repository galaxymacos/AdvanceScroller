using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostEventSystem : MonoBehaviour
{
    public event Action<PlayerCharacter> onPlayerFound;
    public UnityEvent onGhostDie;
    public event Action<DamageData> onGhostTakeDamage;

    public void FindPlayer(PlayerCharacter playerCharacter)
    {
        onPlayerFound?.Invoke(playerCharacter);
    }

    public void GhostDie()
    {
        onGhostDie?.Invoke();
    }

    public void GhostTakeDamage(DamageData damageData)
    {
        onGhostTakeDamage?.Invoke(damageData);
    }

}