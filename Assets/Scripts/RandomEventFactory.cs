using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEventFactory : MonoBehaviour
{
    [SerializeField] private List<RandomEvent> randomEvents;

    private void Start()
    {
        // Test
        SpawnRandomEvent();
    }

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