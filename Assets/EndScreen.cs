using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject pointerPrefab;

    private void Awake()
    {
        End.OnGameEnd += ActivateOptionMenu;
    }

    private void OnDestroy()
    {
        End.OnGameEnd -= ActivateOptionMenu;
    }



    private void ActivateOptionMenu()
    {
        optionMenu.SetActive(true);
        AssignPointerToMenuElement();
    }

    private void AssignPointerToMenuElement()
    {
        
        foreach (NewPlayerInput newPlayerInput in FindObjectsOfType<NewPlayerInput>())
        {
                if (pointerPrefab != null)
                {
                    GameObject pointer = Instantiate(pointerPrefab, transform);
                    pointer.GetComponent<SelectionPointer>().Setup(newPlayerInput);
                }
                else
                {
                    Debug.LogError("Have not assigned pointer for input");
                }
        }
    }
}
