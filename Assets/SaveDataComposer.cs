using System.Collections.Generic;
using UnityEngine;

public static class SaveDataComposer
{
    private static int mapIndex = 2;
    
    // public static void AddMap(int sceneIndex)
    // {
        // mapIndex = sceneIndex;
    // }

    // public static void Reset()
    // {
        // mapIndex = 2;
    // }

    public static FightData ToFightData()
    {
        if(mapIndex == -1)
            Debug.LogError("map data hasn't been initialized");
        FightData fightData = new FightData(PlayerInputStorage.instance.champions, mapIndex);
        return fightData;
    }
}