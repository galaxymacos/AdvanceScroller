using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFuryBar : MonoBehaviour
{
    [SerializeField] private int maxFury;
    private int currentFury;
    private int furyIncreaseFactor = 6;
    
    public int MaxFury => maxFury;
    public int CurrentFury => currentFury;
    public bool IsFuryFull => currentFury == maxFury;
    // Incresse fury by getting hit, by hitting the enemy
    public void IncreaseFury()
    {
        currentFury = Mathf.Min(currentFury + furyIncreaseFactor, maxFury);
    }

    public void ConsumeAllFury()
    {
        currentFury = 0;
    }
}
