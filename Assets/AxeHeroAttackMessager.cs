using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AxeHeroAttackMessager : MonoBehaviour
{
    public GameObject redAxeBuff;
    public GameObject greenAxeBuff;
    public SingleAttackComponent attack;
    public SingleAttackComponent hugeSlash;
    private AxeHeroBuff buffType;

    public UnityEvent onTransformToRed;
    public UnityEvent onTransformToGreen;

    private void Awake()
    {
        buffType = AxeHeroBuff.None;
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

    }

    public void Attack()
    {
        attack.Execute();
    }

    public void HugeSlash()
    {
        hugeSlash.Execute();
    }
}

enum AxeHeroBuff
{
    Red, Green, None
}
