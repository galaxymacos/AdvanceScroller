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

/// <summary>
/// This class is used to select the champion 
/// </summary>
public class HeroPointer
{
    public NewPlayerInput owner;
    public SelectionPanelElement pointingElement;

    public void OnPressed()
    {
        
    }

    public void Navigate()
    {
        // To left
        if (pointingElement.leftElement != null)
        {
            pointingElement = pointingElement.leftElement;
        }
    }
}

public interface Command
{
    void Execute();
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
    private static int mapIndex = -1;
    
    
    public static void AddChampion(GameObject champion)
    {
        champions.Add(champion);
    }

    public static void AddMap(int sceneIndex)
    {
        mapIndex = sceneIndex;
    }

    public static void Reset()
    {
        champions.Clear();
        mapIndex = -1;
    }

    public static FightData ToFightData()
    {
        if(mapIndex == -1)
            Debug.LogError("map data hasn't been initialized");
        FightData fightData = new FightData(champions, mapIndex);
        return fightData;
    }
}