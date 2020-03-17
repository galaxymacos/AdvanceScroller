using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerStorage : MonoBehaviour
{
    public static List<SelectionPointer> pointers;
    public static int ActivatedPointerNumber => CurrentActivatedPointerNumber();

    private void Awake()
    {
        pointers = new List<SelectionPointer>();
        MenuStateMachine.onStateChangedToMap += PointerUtil.ActivateAllPointers;
    }

    private void OnDestroy()
    {
        MenuStateMachine.onStateChangedToMap -= PointerUtil.ActivateAllPointers;
    }

    private static int CurrentActivatedPointerNumber()
    {

        int count = 0;
        foreach (var selectionPointer in FindObjectsOfType<SelectionPointer>())
        {
            count++;
        }
        return count;
    }

}