using System;
using UnityEngine;

public class DropSnowballComponent : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;
    private float spawnTimeCounter;
    [SerializeField] private GameObject snowBallPrefab;
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
        spawnTimeCounter = spawnInterval;
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
                    var snowBall = Instantiate(snowBallPrefab, dropPoint.position, Quaternion.identity);
                    spawnTimeCounter = spawnInterval;
                
                }
            }
        }
        
    }
}