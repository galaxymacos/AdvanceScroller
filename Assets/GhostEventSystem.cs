using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEventSystem : MonoBehaviour
{
    public event Action<PlayerCharacter> onPlayerFound;
    public event Action onGhostDie;

    public void FindPlayer(PlayerCharacter playerCharacter)
    {
        onPlayerFound?.Invoke(playerCharacter);
    }

    public void GhostDie()
    {
        onGhostDie?.Invoke();
    }
}
