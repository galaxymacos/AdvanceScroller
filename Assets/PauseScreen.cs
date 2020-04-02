using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject FirstElementToSelect;

    private void Awake()
    {
        Pause.onPause += SetPauseScreenToActive;
        Pause.onUnpause += SetPauseScreenToDeactive;

    }

    private void OnDestroy()
    {
        Pause.onPause -= SetPauseScreenToActive;
        Pause.onUnpause -= SetPauseScreenToDeactive;
    }

    private void SetPauseScreenToActive()
    {
        pauseScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstElementToSelect);
    }

    private void SetPauseScreenToDeactive()
    {       
        pauseScreen.SetActive(false);

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
