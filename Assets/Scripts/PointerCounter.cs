using UnityEngine;

public static class PointerCounter
{
    private static int pointerNum;

    public static int PointerNum
    {
        get => pointerNum;
        set
        {
            Debug.Log("There are "+value+" pointers in the scene now");
            pointerNum = value;
        }
    }
}