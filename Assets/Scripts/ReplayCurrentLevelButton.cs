using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SelectionPanelElement))]

public class ReplayCurrentLevelButton : MonoBehaviour
{
    
        private SelectionPanelElement selectionPanelElement;

        private void Awake()
        {
            selectionPanelElement = GetComponent<SelectionPanelElement>();
            selectionPanelElement.onBeingClicked += ReplyCurrentLevel;
        }

        private void ReplyCurrentLevel(SelectionPointer selectionPointer)
        {
            PointerCounter.PointerNum = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Update is called once per frame
        void Update()
        {
        
        }
}