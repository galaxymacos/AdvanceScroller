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
        MenuStateMachine.onStateChangedToMap += ActivateAllPointers;
    }

    private static int CurrentActivatedPointerNumber()
    {
        int count = 0;
        foreach (SelectionPointer pointer in pointers)
        {
            if (pointer.IsActivated)
            {
                count++;
            }
        }

        return count;
    }

    private static void ActivateAllPointers()
    {
        foreach (SelectionPointer pointer in pointers)
        {
            pointer.Activate();
        }
    }
}
