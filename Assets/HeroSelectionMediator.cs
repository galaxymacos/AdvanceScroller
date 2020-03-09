using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectionMediator : MonoBehaviour
{
    // private List<SelectionPanelPointer> selectionPanelPointers;
    // private List<SelectionPanelElement> selectionPanelElements;
    //
    //
    // public static int currentActivePointerNumber;
    // private int pointerNumInGame;
    //
    // public static SelectionPanelPointerManager instance;
    //
    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    //
    //     foreach (SelectionPanelPointer selectionPanelPointer in selectionPanelPointers)
    //     {
    //         selectionPanelPointer.gameObject.SetActive(false);
    //     }
    // }
    //
    // public void AssignNewPointerToPlayer(NewPlayerInput input)
    // {
    //     currentActivePointerNumber++;
    //     PlayerInputStorage.instance.AddInput(input);
    //     selectionPanelPointers[pointerNumInGame].gameObject.SetActive(true);
    //     selectionPanelPointers[pointerNumInGame].BindToOwnerInput(input);
    //     selectionPanelPointers[pointerNumInGame].pointingElement.onSelected.Invoke();
    //     pointerNumInGame++;
    // }
}
