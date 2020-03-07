using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputStorage : MonoBehaviour
{
    public List<NewPlayerInput> playerInputs = new List<NewPlayerInput>();
    public List<GameObject> champions = new List<GameObject>();

    public static PlayerInputStorage instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddInput(NewPlayerInput newPlayerInput)
    {
        playerInputs.Add(newPlayerInput);
        champions.Add(null);
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
    
    
}
