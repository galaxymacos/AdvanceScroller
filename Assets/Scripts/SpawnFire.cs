using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject fire;
    public Transform fireSpawnTransform;



    public void SpawnFireFunc()
    {
        Instantiate(fire, fireSpawnTransform.position, Quaternion.identity);

    }
}
