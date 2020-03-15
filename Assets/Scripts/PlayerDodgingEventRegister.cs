using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgingEventRegister : MonoBehaviour
{

    private void Awake()
    {
        PlayerCharacterSpawner.onPlayerSpawnFinished += ActivateDodgingBulletTime;
    }

    
    public void ActivateDodgingBulletTime()
    {
        PlayerCharacter[] players = FindObjectsOfType<PlayerCharacter>();
        foreach (PlayerCharacter player in players)
        {
            player.onPlayerDodgeSucceed += ()=>BulletTimeManager.instance.Register(0.3f);   
        }
        
    }
}
