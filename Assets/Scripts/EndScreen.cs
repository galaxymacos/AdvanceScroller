using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject statisticsPanel;

    public static Action onEndScreenActivate;
    private void Awake()
    {
        End.onGameEnd += ActivateEndMenuElement;

    }

    private void OnDestroy()
    {
        End.onGameEnd -= ActivateEndMenuElement;
    }



    private void ActivateEndMenuElement()
    {
        statisticsPanel.SetActive(true);
        onEndScreenActivate?.Invoke();
    }

    private void AssignPointerToMenuElement()
    {
        
        // foreach (NewPlayerInput newPlayerInput in FindObjectsOfType<NewPlayerInput>())
        // {
                // if (pointerPrefab != null)
                // {
                    // GameObject pointer = Instantiate(pointerPrefab, transform);
                    // pointer.GetComponent<SelectionPointer>().Setup(newPlayerInput);
                // }
                // else
                // {
                    // Debug.LogError("Have not assigned pointer for input");
                // }
        // }
    }
}
