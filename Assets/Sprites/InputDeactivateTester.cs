using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDeactivateTester : MonoBehaviour
{
    private void Awake()
    {
        var pointerCreator = GameObject.Find("Pointer Creator");
        foreach (Transform child in pointerCreator.transform)
        {
            child.gameObject.SetActive(true);
        }

        var selectionPointer = FindObjectsOfType<SelectionPointer>();
        foreach (SelectionPointer pointer in selectionPointer)
        {
            pointer.Activate();
        }
    }
}
