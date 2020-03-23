using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject fire;
    public Transform fireSpawnTransform;

    public float delay = 0.6f;
    // Start is called before the first frame update

    private void Awake()
    {
        print("explosiion");
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                Instantiate(fire, fireSpawnTransform.position, Quaternion.identity);
            }
        }
    }
}
