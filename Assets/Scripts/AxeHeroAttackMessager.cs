using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AxeHeroAttackMessager : MonoBehaviour
{
    public CatchComponent catchComponent;

    public GameObject redAxeBuff;
    public GameObject greenAxeBuff;
    public GameObject axePrefab;
    public Transform axeSpawnPosition;
    public SingleAttackComponent attack;
    public SingleAttackComponent hugeSlash;
    private AxeHeroBuff buffType;

    public UnityEvent onTransformToRed;
    public UnityEvent onTransformToGreen;

    private PlayerCharacter playerCharacter;
    
    private void Awake()
    {
        buffType = AxeHeroBuff.None;
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void Buff()
    {
        if (buffType == AxeHeroBuff.None)
        {
            buffType = AxeHeroBuff.Red;
        }
        else if (buffType == AxeHeroBuff.Red)
        {
            buffType = AxeHeroBuff.Green;
        }
        
    }

    public void StartDetectingCatch()
    {
        catchComponent.Activate();
    }

    public void StopDetectingCatch()
    {
        catchComponent.DeActivate();

    }

    public void SummonAxeBuff()
    {
        if (buffType == AxeHeroBuff.None)
        {
            Instantiate(redAxeBuff, transform.position+new Vector3(0,1.5f), Quaternion.identity);
            onTransformToRed?.Invoke();
        }
        else if (buffType == AxeHeroBuff.Red)
        {
            var buffKing = Instantiate(greenAxeBuff, transform.position+new Vector3(0,1.5f), Quaternion.identity);
            buffKing.GetComponent<SpriteRenderer>().color =Color.green;
            onTransformToGreen?.Invoke();
        }
        else
        {
            return;
        }

    }

    public void ThrowAxe()
    {
        GameObject axe = Instantiate(axePrefab, axeSpawnPosition.position, Quaternion.identity);
        Projectile projectile = axe.GetComponent<Projectile>();
        projectile.Setup(playerCharacter, 10, 60);
    }

    public void Attack()
    {
        print("attack");
        attack.Execute();
    }

    public void HugeSlash()
    {
        print("huge slash");
        hugeSlash.Execute();
    }
}

enum AxeHeroBuff
{
    Red, Green, None
}
