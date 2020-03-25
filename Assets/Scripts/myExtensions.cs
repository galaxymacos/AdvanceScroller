using System;
using UnityEngine;

public static class myExtensions
{
    public static AudioType GetAudioType(this string str)
    {
        bool result = Enum.TryParse(str, false, out AudioType audioType);
        return result?audioType:AudioType.None;
    }
}