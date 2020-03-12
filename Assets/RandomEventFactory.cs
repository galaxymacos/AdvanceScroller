using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventFactory : MonoBehaviour
{
    [SerializeField] private List<RandomEvent> randomEvents;

    public void SpawnRandomEvent()
    {
        var randomEvent = randomEvents[Random.Range(0, randomEvents.Count)];
        randomEvent.Execute();
    }
}

public abstract class RandomEvent: MonoBehaviour
{
    public abstract void Execute();
}

public class GeneratePotionEvent : RandomEvent
{
    
    public override void Execute()
    {
        
    }
}