using System;
using System.Collections;
using UnityEngine;

public class SelectionPanelElement : MonoBehaviour
{
    public SelectionPanelElement leftElement;
    public SelectionPanelElement rightElement;
    public SelectionPanelElement topElement;
    public SelectionPanelElement downElement;

    public Action onSelected;
    public Action onDeselected;

    [Tooltip("What champion does this sprite indicate")]
    public GameObject champion;
}


