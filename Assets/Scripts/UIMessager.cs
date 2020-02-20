using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMessager : MonoBehaviour
{
    public List<PlayerPanel> playerPanels;
    public List<PlayerSkillPanel> playerSkillPanels;
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
            for (int i = 0; i < characters.Count; i++)
            {
                playerPanels[i].player = characters[i];
            }
        }

        foreach (PlayerPanel playerPanel in playerPanels)
        {
            playerPanel.onPlayerSetup?.Invoke();
        }
        
        

        if (characters.Count == playerSkillPanels.Count)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                playerSkillPanels[i].owner = characters[i];
            }
        }
        foreach (PlayerSkillPanel playerSkillPanel in playerSkillPanels)
        {
            playerSkillPanel.onPlayerSetup?.Invoke();
        }
    }
}
