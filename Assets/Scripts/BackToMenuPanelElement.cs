using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SelectionPanelElement))]
public class BackToMenuPanelElement : MonoBehaviour
{
    private SelectionPanelElement selectionPanelElement;

    private void Awake()
    {
        selectionPanelElement = GetComponent<SelectionPanelElement>();
        selectionPanelElement.onBeingClicked += BackToMenu;
    }

    private void BackToMenu(SelectionPointer selectionPointer)
    {
        print("back to hero selection");
     
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
