using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateMachineMessager: MonoBehaviour
{
    private List<PlayerCharacter> playerCharacters;
    private List<UltimateComponent> ultimateComponents;
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
        End.OnGameEnd += UnPauseAll;
        Play.OnGameStart += ClearInput;
    }

    public void InitializePlayers()
    {
        playerCharacters = FindObjectsOfType<PlayerCharacter>().ToList();
        ultimateComponents = FindObjectsOfType<UltimateComponent>().ToList();
    }

    private void OnDestroy()
    {
        foreach (NewPlayerInput newPlayerInput in FindObjectsOfType<NewPlayerInput>())
        {
            newPlayerInput.onPauseButtonPressed -= PauseButtonPress;
        }
        End.OnGameEnd -=DeRegisterInputFromPlayer;
        End.OnGameEnd -= UnPauseAll;
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

    public bool ShouldTransferToGameEnd()
    {
        bool allUltimateOver = true;
        foreach (var ultimateComponent in ultimateComponents)
        {
            if (ultimateComponent.isPlayingUltimate)
            {
                allUltimateOver = false;
            }
        }
        return EndSlowMotion.slowMotionTimeCounter <= 0 && allUltimateOver;
    }

    private void UnPauseAll()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.UnPause();
        }
        
        var characters = FindObjectsOfType<PlayerCharacter>();
        foreach (var character in characters)
        {
            character.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
    
        
}