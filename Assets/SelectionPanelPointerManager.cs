using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPanelPointerManager: MonoBehaviour
{
    public static int currentActivePointerNumber;
    private int pointerNumInGame;
    [SerializeField] private List<SelectionPanelPointer> selectionPanelPointers;

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

        foreach (SelectionPanelPointer selectionPanelPointer in selectionPanelPointers)
        {
            selectionPanelPointer.gameObject.SetActive(false);
        }
    }

    public void AssignNewPointerToPlayer(NewPlayerInput input)
    {
        currentActivePointerNumber++;
        PlayerInputStorage.instance.AddInput(input);
        selectionPanelPointers[pointerNumInGame].gameObject.SetActive(true);
        selectionPanelPointers[pointerNumInGame].BindToOwnerInput(input);
        selectionPanelPointers[pointerNumInGame].pointingElement.onSelected.Invoke();
        pointerNumInGame++;
    }
}