using System;
using System.Collections;
using UnityEngine;

public class SelectionPanelElement : MonoBehaviour
{
    public SelectionPanelElement leftElement;
    public SelectionPanelElement rightElement;
    public SelectionPanelElement topElement;
    public SelectionPanelElement downElement;

    [Tooltip("What champion does this sprite indicate")]
    public GameObject champion;

    
}

public class ChampionSelectionCommand : Command
{
    public GameObject championToSelect;

    public ChampionSelectionCommand(GameObject championToSelect)
    {
        this.championToSelect = championToSelect;
    }
    
    public void Execute()
    {
        // Add the champion selected to the list of champions and disable the current pointer because 
    }
}