using UnityEngine;

public static class PointerUtil{
    public static void ActivateAllPointers()
    {
        foreach (Transform pointer in PointerCreator.instance.transform)
        {
            pointer.gameObject.SetActive(true);
            pointer.GetComponent<SelectionPointer>().Activate();
        }
    }

}