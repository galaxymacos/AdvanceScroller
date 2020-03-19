using System.Collections.Generic;
using UnityEngine;

public class GeneratePotionEvent : RandomEvent
{
    public List<GameObject> potions;
    public override void Execute()
    {
        GenerateRandomPotion();
    }

    private void GenerateRandomPotion()
    {
        GameObject potion = potions[Random.Range(0,potions.Count)];
        Transform generatedPosition =
            MapInfo.instance.itemGeneratedPositions[Random.Range(0, MapInfo.instance.itemGeneratedPositions.Count)];
        Instantiate(potion, generatedPosition.transform.position, Quaternion.identity);
    }
}