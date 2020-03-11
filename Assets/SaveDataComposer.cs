using System.Collections.Generic;
using UnityEngine;

public static class SaveDataComposer
{
    private static int _mapIndex = -1;
    public static int MapIndex => _mapIndex;

    public static void SetMapIndex(int mapIndex)
    {
        _mapIndex = mapIndex;
    }
    

    public static FightData ToFightData()
    {
        if (_mapIndex == -1)
        {
            Debug.LogError("map data hasn't been initialized");
            return null;
        }

        FightData fightData = new FightData(PlayerInputStorage.instance.champions, _mapIndex);
        return fightData;
    }
}