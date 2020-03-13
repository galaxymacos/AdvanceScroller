using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameEndDetector : MonoBehaviour
{

    private List<PlayerCharacter> playerCharacters;


    public static Action onGameEnd;
    private void Awake()
    {
        PlayerCharacterSpawner.onPlayerSpawnFinished += Setup;
    }

    private void Setup()
    {
        playerCharacters = FindObjectsOfType<PlayerCharacter>().ToList();
    }
    
    

    private bool CheckGameEnd()
    {
        int playerAliveCount = 0;
        foreach (var playerCharacter in playerCharacters)
        {
            if (!playerCharacter.isDead)
            {
                playerAliveCount++;
            }
        }

        return playerAliveCount < 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckGameEnd())
        {
            print("Game Ends because of less than 2 player in the scene");
            onGameEnd?.Invoke();
        }
    }
}
