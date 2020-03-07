using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FightData
{
    public List<GameObject> champions;
    public int fightSceneIndex;
    
    public FightData(List<GameObject> champions, int fightSceneIndex)
    {
        this.champions = champions;
        this.fightSceneIndex = fightSceneIndex;
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}