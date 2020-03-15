using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputStorage : MonoBehaviour
{
    [HideInInspector] public List<NewPlayerInput> playerInputs;
    [HideInInspector] public List<GameObject> champions;
    [HideInInspector] public List<int> mapIndexes;
    public static PlayerInputStorage instance;
    public static Action<NewPlayerInput> onNewInputAdded;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        playerInputs = new List<NewPlayerInput>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        onNewInputAdded += StoreInput;
    }

    /// <summary>
    /// driven by event
    /// </summary>
    /// <param name="newPlayerInput"></param>
    private void StoreInput(NewPlayerInput newPlayerInput)
    {
        playerInputs.Add(newPlayerInput);
        champions.Add(null);
        mapIndexes.Add(-1);
    }

    public void SetChampionForInput(NewPlayerInput input, GameObject champion)
    {
        for (int i = 0; i < playerInputs.Count; i++)
        {
            if (playerInputs[i] == input)
            {
                champions[i] = champion;
            }
        }
    }
    
    public void SetMapIndexForInput(NewPlayerInput input, int mapIndex)
    {
        for (int i = 0; i < playerInputs.Count; i++)
        {
            if (playerInputs[i] == input)
            {
                mapIndexes[i] = mapIndex;
            }
        }
    }

 
}
