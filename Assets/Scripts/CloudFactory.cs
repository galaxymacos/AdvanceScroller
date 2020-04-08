using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFactory : MonoBehaviour
{
    public GameObject cloud;

    public Transform cloudSpawnPoint;

    private void Awake()
    {
        IceSlideEventSystem.onIceSlideDestroy += GenerateCloud;
    }


    private void GenerateCloud()
    {
        Instantiate(cloud, cloudSpawnPoint.position, Quaternion.identity);
    }
}
