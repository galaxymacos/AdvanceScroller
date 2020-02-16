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
        PlayerCharacterSpawner.onPlayerSpawnFinished += Setup;
    }


    public void Setup()
    {
        List<PlayerCharacter> characters = PlayerCharacterSpawner.instance.charactersForPlayer;
        if (characters.Count == playerPanels.Count)
        {
            print(characters.Count);
            for (int i = 0; i < characters.Count; i++)
            {
                playerPanels[i].player = characters[i];
            }
        }

        foreach (PlayerPanel playerPanel in playerPanels)
        {
            playerPanel.onPlayerSetup?.Invoke();
        }
    }
}
