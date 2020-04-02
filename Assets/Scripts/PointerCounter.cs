using UnityEngine;

public static class PointerCounter
{
    private static int pointerNum;

    public static int PointerNum
    {
        get => pointerNum;
        set
        {
            pointerNum = value;
        }
    }
}