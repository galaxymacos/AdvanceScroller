using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject statisticsPanel;
    public GameObject pointerPrefab;

    public static Action onEndScreenActivate;
    private void Awake()
    {
        End.OnGameEnd += ActivateEndMenuElement;
        onEndScreenActivate+=AssignPointerToMenuElement;

    }

    private void OnDestroy()
    {
        End.OnGameEnd -= ActivateEndMenuElement;
        onEndScreenActivate-=AssignPointerToMenuElement;
    }



    private void ActivateEndMenuElement()
    {
        optionMenu.SetActive(true);
        statisticsPanel.SetActive(true);
        onEndScreenActivate?.Invoke();
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
