using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionElementStorage : MonoBehaviour
{
    public SelectionPanelElement FirstElement => firstElement;
    public List<SelectionPanelElement> ChampionUI => championUI;
    public SelectionPanelElement FirstElementMap => firstElementMap;
    public List<SelectionPanelElement> MapUI => mapUI;

    [SerializeField] private SelectionPanelElement firstElement;
    [SerializeField] private SelectionPanelElement firstElementMap;
    [SerializeField] private List<SelectionPanelElement> championUI;
    [SerializeField] private List<SelectionPanelElement> mapUI;


    private void ChangeSelectionElementToMapMode()
    {
        firstElement = FirstElementMap;
        foreach (var championElement in championUI)
        {
            if (championElement != null)
            {
                championElement.gameObject.SetActive(false);
            }
        }

        foreach (var mapElement in mapUI)
        {
            if (mapElement != null)
            {
                mapElement.gameObject.SetActive(true);
            }
        }
    }


    public void SetFirstElement(SelectionPanelElement newElement)
    {
        firstElement = newElement;
    }
    
    

    public static SelectionElementStorage instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        MenuStateMachine.onStateChangingToMap += ChangeSelectionElementToMapMode;
    }

}
