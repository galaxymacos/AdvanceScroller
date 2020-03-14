using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateMachineMessager: MonoBehaviour
{
    private List<PlayerCharacter> playerCharacters;
    private bool isPausing;

    public bool IsPausing => isPausing;


    private void Awake()
    {
        PlayerCharacterSpawner.onPlayerSpawnFinished += ()=>playerCharacters = FindObjectsOfType<PlayerCharacter>().ToList();
        foreach (NewPlayerInput newPlayerInput in FindObjectsOfType<NewPlayerInput>())
        {
            newPlayerInput.onPauseButtonPressed += PauseButtonPress;
        }
    }

    public bool GameEndConditionMeets()
    {
        int playerAliveCount = 0;
        foreach (var playerCharacter in playerCharacters)
        {
            if (!playerCharacter.isDead)
            {
                playerAliveCount++;
                
            }
        }

        return playerAliveCount <= 1;
    }

    private void PauseButtonPress()
    {
        isPausing = !isPausing;
    }
    
}