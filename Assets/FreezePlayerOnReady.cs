using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayerOnReady : MonoBehaviour
{
    private void Awake()
    {
        GameStateMachine.gameIsPause = true;
    }

    private void OnDisable()
    {
        GameStateMachine.gameIsPause = false;
    }
}
