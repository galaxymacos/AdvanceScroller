using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    
    private SelectionPanelElement selectionPanelElement;

    private void Awake()
    {
        selectionPanelElement = GetComponent<SelectionPanelElement>();
        selectionPanelElement.onBeingClicked += ExitGame;
    }

    private void ExitGame(SelectionPointer selectionPointer)
    {
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}