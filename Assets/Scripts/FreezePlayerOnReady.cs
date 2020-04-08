using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayerOnReady : MonoBehaviour
{
    private void Awake()
    {
        PlayerCharacterSpawner.onPlayerSpawnFinished += Pause;
    }

    private void Pause()
    {
        GameStateMachine.gameIsPause = true;
    }

    private void OnDestroy()
    {
        PlayerCharacterSpawner.onPlayerSpawnFinished -= Pause;
    }

    private void OnDisable()
    {
        GameStateMachine.gameIsPause = false;
    }
}
