using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BanditPlayerDetector : MonoBehaviour
{
    public BanditEventSystem banditEventSystem;
    public BanditData banditData;

    [HideInInspector] public List<PlayerCharacter> playersInRange;

    public PlayerCharacter TargetPlayer
    {
        get
        {
            PlayerCharacter result = null;
            float distance = 100000f;
            for (int i = 0; i < playersInRange.Count; i++)
            {
                if (Vector3.Distance(playersInRange[i].transform.position, transform.position) < distance)
                {
                    result = playersInRange[i];
                    distance = Vector3.Distance(playersInRange[i].transform.position, transform.position);
                }
            }

            return result;
        }
    }

    private void Awake()
    {
        playersInRange = new List<PlayerCharacter>();
    }

    private void Update()
    {
        if (playersInRange.Count > 0)
        {
            banditData.alertTimeCounter = banditData.alertTime;
        }
        
        if (banditData.alertTimeCounter > 0)
        {
            banditData.alertTimeCounter -= Time.deltaTime;
            if (banditData.alertTimeCounter <= 0)
            {
                banditData.targetPlayer = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerCharacter = other.gameObject.GetComponent<PlayerCharacter>();
        if (playerCharacter != null && !playersInRange.Contains(playerCharacter))
        {
            banditEventSystem.PlayerEnterDetectRange(playerCharacter);
            playersInRange.Add(playerCharacter);
            banditData.targetPlayer = playersInRange[Random.Range(0, playersInRange.Count)];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var playerCharacter = other.gameObject.GetComponent<PlayerCharacter>();
        if (playerCharacter != null && playersInRange.Contains(playerCharacter))
        {
            banditEventSystem.PlayerExitDetectRange(playerCharacter);
            playersInRange.Remove(playerCharacter);
            
        }

    }
}
