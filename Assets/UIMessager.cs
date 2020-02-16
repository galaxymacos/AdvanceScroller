using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMessager : MonoBehaviour
{
    public List<PlayerPanel> playerPanels;
    // Start is called before the first frame update

    private void Awake()
    {
        PlayerCharacterSpawner.instance.onPlayerSpawnFinished += Setup;
    }


    public void Setup()
    {
        List<PlayerCharacter> characters = PlayerCharacterSpawner.instance.charactersForPlayer;
        
        
        for (int i = 0; i < playerPanels.Count; i++)
        {
            
        }
    }
}
