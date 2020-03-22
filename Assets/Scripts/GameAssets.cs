using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets i
    {
        get
        {
            if (_instance == null) _instance = (Resources.Load("GameAssets") as GameObject)?.GetComponent<GameAssets>();
            return _instance;
        }
    }

    
    
}