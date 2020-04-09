using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionCollecter))]
public class SamuraiDomain : MonoBehaviour
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
        playerCharacter.limitersForAtk.Add(Debuff_IncreaseDamageTaken);
    }

    private void RemoveDebuffToOtherPlayer(PlayerCharacter playerCharacter)
    {
        playerCharacter.limitersForMS.Remove(Debuff_SlowDown);
        playerCharacter.limitersForAtk.Remove(Debuff_IncreaseDamageTaken);
    }
    
    private void ApplyBuffToOwner(PlayerCharacter playerCharacter)
    {
        playerCharacter.limitersForMS.Add(Buff_IncreaseSpeed);
        playerCharacter.limitersForJS.Add(Buff_IncreaseJumpSpeed);
    }
    
    private void RemoveBuffToOwner(PlayerCharacter playerCharacter)
    {
        playerCharacter.limitersForMS.Remove(Buff_IncreaseSpeed);
        playerCharacter.limitersForJS.Remove(Buff_IncreaseJumpSpeed);
    }


    #region Buff
    
    [SerializeField] private float speedBoostRatio = 0.2f;
    [SerializeField] private float jumpSpeedBoostRatio = 0.3f;
    private float Buff_IncreaseSpeed(float ms)
    {
        return ms * (1 + speedBoostRatio);
    }
    private float Buff_IncreaseJumpSpeed(float js)
    {
        return js * (1 + jumpSpeedBoostRatio);
    }

    #endregion
    
    #region Debuff

    [SerializeField] private float slowRatio = 0.3f;
    [SerializeField] private float damageTakenIncreaseRatio = 0.3f;

    private float Debuff_IncreaseDamageTaken(float damage)
    {
        return damage * (1 + damageTakenIncreaseRatio);
    }
    private float Debuff_SlowDown(float ms)
    {
        return ms * (1-slowRatio);
    }

    #endregion
    
}

