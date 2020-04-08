using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToUnpause : MonoBehaviour
{
    public void Trigger()
    {
        GameStateMachineMessager.instance.PauseButtonPress();
    }
}
