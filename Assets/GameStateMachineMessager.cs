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
        PlayerCharacterSpawner.onPlayerSpawnFinished += InitializePlayers;
        foreach (NewPlayerInput newPlayerInput in FindObjectsOfType<NewPlayerInput>())
        {
            newPlayerInput.onPauseButtonPressed += PauseButtonPress;
        }

        End.OnGameEnd += DeRegisterInputFromPlayer;
        Play.OnGameStart += ClearInput;
    }

    public void InitializePlayers()
    {
        playerCharacters = FindObjectsOfType<PlayerCharacter>().ToList();
    }

    private void OnDestroy()
    {
        foreach (NewPlayerInput newPlayerInput in FindObjectsOfType<NewPlayerInput>())
        {
            newPlayerInput.onPauseButtonPressed -= PauseButtonPress;
        }
        End.OnGameEnd -=DeRegisterInputFromPlayer;
        PlayerCharacterSpawner.onPlayerSpawnFinished -= InitializePlayers;
    }

    public bool GameEndConditionMeets()
    {
        int playerAliveCount = 0;
        foreach (var playerCharacter in FindObjectsOfType<PlayerCharacter>())
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

    private void DeRegisterInputFromPlayer()
    {
        foreach (var playerCharacter in FindObjectsOfType<PlayerCharacter>())
        {
            playerCharacter.playerInput = null;
        }
    }

    private void ClearInput()
    {
        PointerCounter.PointerNum = 0;
        foreach (SelectionPointer selectionPointer in FindObjectsOfType<SelectionPointer>())
        {
            Destroy(selectionPointer.gameObject);
        }
    }
}