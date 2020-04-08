using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionCollecter))]
public class UltraSpace : MonoBehaviour
{
    private CollisionCollecter collisionCollector;

    private PlayerCharacter owner;
    public void Setup(PlayerCharacter _owner)
    {
        owner = _owner;
    }

    
    private void Awake()
    {
        collisionCollector = GetComponent<CollisionCollecter>();
        collisionCollector.onCollisionDetect += RecordPlayer;
        collisionCollector.onCollisionRemove += ClearPlayer;
    }

    private void RecordPlayer(Collider2D obj)
    {
        PlayerCharacter player = obj.GetComponent<PlayerCharacter>();
        if (player == null)
        {
            Debug.LogError("There is no player character in the collision");
        }
        if (player == owner)
        {
            ApplyBuffToOwner(player);
            print("apply buff to owner");
        }
        else
        {
            print("apply debuff to the other players");
            ApplyDebuffToOtherPlayer(player);
        }
    }

    private void ClearPlayer(Collider2D obj)
    {
        PlayerCharacter player = obj.GetComponent<PlayerCharacter>();
        if (player == null)
        {
            Debug.LogError("There is no player character in the collision");
        }
        if (player == owner)
        {
            RemoveBuffToOwner(player);
        }
        else
        {
            RemoveDebuffToOtherPlayer(player);
        }
    }

    private void OnDestroy()
    {
        collisionCollector.onCollisionDetect -= RecordPlayer;
        collisionCollector.onCollisionRemove -= ClearPlayer;
    }

    private void ApplyDebuffToOtherPlayer(PlayerCharacter playerCharacter)
    {
        playerCharacter.limitersForMS.Add(Debuff_SlowDown);
    }

    private void RemoveDebuffToOtherPlayer(PlayerCharacter playerCharacter)
    {
        playerCharacter.limitersForMS.Remove(Debuff_SlowDown);
    }
    
    private void ApplyBuffToOwner(PlayerCharacter playerCharacter)
    {
        playerCharacter.limitersForMS.Add(Buff_IncreaseSpeed);
    }
    
    private void RemoveBuffToOwner(PlayerCharacter playerCharacter)
    {
        playerCharacter.limitersForMS.Remove(Buff_IncreaseSpeed);
    }


    #region Buff
    
    [SerializeField] private float speedBoostRatio = 0.3f;
    private float Buff_IncreaseSpeed(float ms)
    {
        return ms * (1 + speedBoostRatio);
    }

    #endregion
    
    #region Debuff

    [SerializeField] private float slowRatio = 0.3f;
    private float Debuff_SlowDown(float ms)
    {
        return ms * (1-slowRatio);
    }

    #endregion
    
}

