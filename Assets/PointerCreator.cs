using System;
using System.Collections.Generic;
using UnityEngine;

public class PointerCreator : MonoBehaviour
{
    public GameObject pointerPrefab;
    private void Awake()
    {
        PlayerInputStorage.onNewInputAdded += CreatePointerForInput;
    }

    /// <summary>
    /// Call by event to assign a pointer to every player input
    /// </summary>
    /// <param name="input"></param>
    private void CreatePointerForInput(NewPlayerInput input)
    {
        if (pointerPrefab != null)
        {
            GameObject pointer = Instantiate(pointerPrefab, transform);
            pointer.GetComponent<SelectionPointer>().Setup(input);
            PointerStorage.pointers.Add(pointer.GetComponent<SelectionPointer>());
        }
        else
        {
            Debug.LogError("Have not assigned pointer for input");
        }
    }
}