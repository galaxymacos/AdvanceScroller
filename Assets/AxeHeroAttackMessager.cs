using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHeroAttackMessager : MonoBehaviour
{
    public GameObject redAxeBuff;
    public GameObject greenAxeBuff;
    private AxeHeroBuff buffType;

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
            Instantiate(redAxeBuff, transform.position, Quaternion.identity);
        }
        else if (buffType == AxeHeroBuff.Red)
        {
            var buffKing = Instantiate(greenAxeBuff, transform.position, Quaternion.identity);
            buffKing.GetComponent<SpriteRenderer>().color =Color.green;
        }

    }
}

enum AxeHeroBuff
{
    Red, Green, None
}
