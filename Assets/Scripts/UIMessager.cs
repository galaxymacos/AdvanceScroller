using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMessager : MonoBehaviour
{
    public List<GameObject> PlayerPanels;
    
    // Start is called before the first frame update
    
    private void Awake()
    {
        PlayerCharacterSpawner.onPlayerSpawnFinished += SetupPlayerUi;
    }

    

    public void SetupPlayerUi()
    {
        List<PlayerCharacter> characters = PlayerCharacterSpawner.instance.charactersForPlayer;


        for (int i = 0; i < characters.Count; i++)
        {
            PlayerPanels[i].SetActive(true);
            PlayerPanel playerPanel = PlayerPanels[i].GetComponent<PlayerPanel>();
            playerPanel.player = characters[i];
            playerPanel.onPlayerSetup?.Invoke();
            PlayerSkillPanel playerSkillPanel = PlayerPanels[i].transform.GetComponentInChildren<PlayerSkillPanel>();
            playerSkillPanel.owner = characters[i];
            playerSkillPanel.onPlayerSetup?.Invoke();
        }
    }
}
