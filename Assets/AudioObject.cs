using System;
using UnityEngine;

[Serializable]
public class AudioObject
{
    public string typeInString;
    public AudioType type
    {
        get
        {
            bool parseResult = Enum.TryParse(typeInString, true, out AudioType result);
            if (!parseResult)
            {
                Debug.LogError($"Can't find the audio type with the name {typeInString}");
            }
            return result;
        }
    }

    public AudioClip clip;
}