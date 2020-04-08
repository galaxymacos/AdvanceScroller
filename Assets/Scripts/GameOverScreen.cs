using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameoverScreen;
    [SerializeField] private GameObject FirstElementToSelect;

    private void Awake()
    {
        End.onGameEnd += SetGameOverScreenToActive;

    }

    private void OnDestroy()
    {
        End.onGameEnd -= SetGameOverScreenToActive;
    }

    private void SetGameOverScreenToActive()
    {
        gameoverScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstElementToSelect);
    }
}
