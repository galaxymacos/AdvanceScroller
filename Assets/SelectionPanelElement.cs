using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPanelElement : MonoBehaviour
{
    public SelectionPanelElement leftElement;
    public SelectionPanelElement rightElement;
    public SelectionPanelElement topElement;
    public SelectionPanelElement downElement;

    [Tooltip("What champion does this sprite indicate")]
    public GameObject champion;

    
}

public class ChampionSelectionCommand : Command
{
    public GameObject championToSelect;

    public ChampionSelectionCommand(GameObject championToSelect)
    {
        this.championToSelect = championToSelect;
    }
    
    public void Execute()
    {
        // Add the champion selected to the list of champions and disable the current pointer because 
    }
}

public static class SaveDataComposer
{
    private static readonly List<GameObject> champions = new List<GameObject>();
    private static int mapIndex = 2;
    
    
    // public static void AddChampion(GameObject champion)
    // {
        // champions.Add(champion);
    // }

    public static void AddMap(int sceneIndex)
    {
        mapIndex = sceneIndex;
    }

    public static void Reset()
    {
        champions.Clear();
        mapIndex = 2;
    }

    public static FightData ToFightData()
    {
        if(mapIndex == -1)
            Debug.LogError("map data hasn't been initialized");
        FightData fightData = new FightData(PlayerInputStorage.instance.champions, mapIndex);
        return fightData;
    }
}