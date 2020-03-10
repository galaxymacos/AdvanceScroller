using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPanelPointerManager: MonoBehaviour
{
    public static int currentActivePointerNumber;
    private int pointerNumInGame;
    [HideInInspector] public List<SelectionPanelPointer> selectionPanelPointers = new List<SelectionPanelPointer>();

    public GameObject pointerPrefab;

    public static SelectionPanelPointerManager instance;

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

        // foreach (SelectionPanelPointer selectionPanelPointer in selectionPanelPointers)
        // {
            // selectionPanelPointer.gameObject.SetActive(false);
        // }
    }

    public void AssignNewPointerToPlayer(NewPlayerInput input)
    {
        if (pointerPrefab != null)
        {
            PlayerInputStorage.instance.AddInput(input);
            currentActivePointerNumber++;
            GameObject pointer = Instantiate(pointerPrefab,transform);
            pointer.GetComponent<SelectionPanelPointer>().BindToOwnerInput(input);
            pointer.GetComponent<SelectionPanelPointer>().pointingElement = GetFirstPointingElement();
            pointer.GetComponent<SelectionPanelPointer>().pointingElement.onSelected.Invoke();
            selectionPanelPointers.Add(pointer.GetComponent<SelectionPanelPointer>());
        }
        
        // currentActivePointerNumber++;
        // PlayerInputStorage.instance.AddInput(input);
        //
        // selectionPanelPointers[pointerNumInGame].gameObject.SetActive(true);
        // selectionPanelPointers[pointerNumInGame].BindToOwnerInput(input);
        // selectionPanelPointers[pointerNumInGame].pointingElement.onSelected.Invoke();
        // pointerNumInGame++;
    }

    private SelectionPanelElement GetFirstPointingElement()
    {
        var selectionPanelElement = FindObjectOfType<SelectionPanelElement>();
        return selectionPanelElement;
    }
}