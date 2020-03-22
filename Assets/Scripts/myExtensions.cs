using System;

public static class myExtensions
{
    public static AudioType GetAudioType(this string str)
    {
        Enum.TryParse(str, true, out AudioType audioType);
        return audioType;
    }
}