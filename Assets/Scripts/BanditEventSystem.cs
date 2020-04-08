using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditEventSystem : MonoBehaviour
{
    public event Action goToNearEdge;
    public event Action<PlayerCharacter> onPlayerEnterDetectRange;
    public event Action<PlayerCharacter> onPlayerExitDetectRange;
    public event Action<PlayerCharacter> onPlayerEnterAttackRange;
    public event Action<PlayerCharacter> onPlayerExitAttackRange;

    public void GoNearEdge()
    {
        goToNearEdge?.Invoke();
    }

    public void PlayerEnterDetectRange(PlayerCharacter playerCharacter)
    {
        onPlayerEnterDetectRange?.Invoke(playerCharacter);
    }
    
    public void PlayerExitDetectRange(PlayerCharacter playerCharacter)
    {
        onPlayerExitDetectRange?.Invoke(playerCharacter);
    }

    public void PlayerEnterAttackRange(PlayerCharacter playerCharacter)
    {
        onPlayerEnterAttackRange?.Invoke(playerCharacter);
    }

    public void PlayerExitAttackRange(PlayerCharacter playerCharacter)
    {
        onPlayerExitAttackRange?.Invoke(playerCharacter);
    }

    
}
