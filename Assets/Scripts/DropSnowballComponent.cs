using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropSnowballComponent : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;
    [Tooltip("If the value is 0.5f, then the item will be spawned in an interval of (spawnInterval-0.5, spawnInterval+0.5)")]
    [SerializeField] private float spawnIntervalVariedRange = 1f;
    private float spawnTimeCounter;
    [SerializeField] private GameObject[] itemsToDrop;
    [SerializeField] private Transform dropPoint;

    private bool isRunning;
    private void Awake()
    {
        IceSlideEventSystem.onIceSlideStart += SetRunning;
        IceSlideEventSystem.onIceSlideFinish += StopRunning;
    }

    private void OnDestroy()
    {
        IceSlideEventSystem.onIceSlideStart -= SetRunning;
        IceSlideEventSystem.onIceSlideFinish -= StopRunning;
    }


    private void SetRunning()
    {
        isRunning = true;
        ResetSpawnTimeCounter();
    }

    private void ResetSpawnTimeCounter()
    {
        spawnTimeCounter = Random.Range(spawnInterval-spawnIntervalVariedRange, spawnInterval + spawnIntervalVariedRange);
    }

    private void StopRunning()
    {
        isRunning = false;
    }

    private void Update()
    {

        if (isRunning)
        {
            if (spawnTimeCounter > 0)
            {
                spawnTimeCounter -= Time.deltaTime;
                if (spawnTimeCounter <= 0)
                {
                    var item = Instantiate(itemsToDrop[Random.Range(0, itemsToDrop.Length)], dropPoint.position, Quaternion.identity);
                    IceSlideEventSystem.instance.IceSlideDropItem(item);
                    ResetSpawnTimeCounter();
                }
            }
        }
        
    }
}