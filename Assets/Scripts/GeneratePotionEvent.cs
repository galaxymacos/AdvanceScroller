using System.Collections.Generic;
using UnityEngine;

public class GeneratePotionEvent : RandomEvent
{
    public List<GameObject> potions;
    public Transform[] potionSpawnLocations;
    public override void Execute()
    {
        GenerateRandomPotion();
    }

    private void GenerateRandomPotion()
    {
        GameObject potion = potions[Random.Range(0,potions.Count)];
        
        Transform generatedPosition =
            potionSpawnLocations[Random.Range(0, potionSpawnLocations.Length)];
        
        
        Instantiate(potion, generatedPosition.transform.position, Quaternion.identity);
    }
}