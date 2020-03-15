using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDistributor : MonoBehaviour
{
    private static int _currentPlayerInputNum = 0;

    public static PlayerInputDistributor instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            print("Can't have more than one "+name);
            Destroy(gameObject);
        }

        MenuStateMachine.onSelectionChangeToSelectHero += AssignPointerToChampionFromMainGame;
    }

    private void OnDestroy()
    {
        MenuStateMachine.onSelectionChangeToSelectHero -= AssignPointerToChampionFromMainGame;
    }

    private void Start()
    {
        _currentPlayerInputNum = FindObjectsOfType<NewPlayerInput>().Length;
    }

    /// <summary>
    /// This method is trying to find all the existing player input and assign one pointer to each of them at the beginning of the game
    /// </summary>
    public void AssignPointerToChampionFromMainGame()
    {
        var playerInputGroup = FindObjectsOfType<NewPlayerInput>().ToList();
        if (playerInputGroup.Count > 0)
        {
            print("Actually assigning");
            int currentPointerFound = 0;
            foreach (var playerInput in playerInputGroup)
            {
                PlayerCharacterSpawner.instance.charactersForPlayer[currentPointerFound++].playerInput = playerInput;
            }
            _currentPlayerInputNum = currentPointerFound;
        }
        else
        {
            return;
        }
        
        
        
    }


    public void DistributeInputToPlayerCharacter(NewPlayerInput input)
    {
        if (_currentPlayerInputNum >= PlayerCharacterSpawner.instance.charactersForPlayer.Count)
        {
            print("No player for this controller to control");
            return;
        }
        PlayerCharacterSpawner.instance.charactersForPlayer[_currentPlayerInputNum].playerInput = input;
        print("distribute the generated player input object to the player "+_currentPlayerInputNum);
        _currentPlayerInputNum++;

    }
}


