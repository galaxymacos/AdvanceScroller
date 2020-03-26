using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEventSystem : MonoBehaviour
{
    public event Action<PlayerCharacter> onPlayerFound;

    public void FindPlayer(PlayerCharacter playerCharacter)
    {
        onPlayerFound?.Invoke(playerCharacter);
    }
}
