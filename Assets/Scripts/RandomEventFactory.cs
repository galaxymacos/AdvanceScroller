using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEventFactory : MonoBehaviour
{
    [SerializeField] private List<RandomEvent> randomEvents;

    public float spawnEventInterval = 2f;
    private float spawnEventCounter;
    
    private void Start()
    {
        spawnEventCounter = spawnEventInterval;
    }

    private void Update()
    {
        if (spawnEventCounter > 0)
        {
            spawnEventCounter -= Time.deltaTime;
            if (spawnEventCounter <= 0)
            {
                SpawnRandomEvent();
                spawnEventCounter = spawnEventInterval;
            }
        }
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