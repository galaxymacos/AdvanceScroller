using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject explosion;

    public Transform explosionSpawnTransform;

 
    private void Start()
    {
        InfiniteSoundPlayer.instance.PlayAudio(AudioType.Lightning);
    }
    
    // Animation event
    public void SpawnLightningAfterEffect()
    {
        Instantiate(explosion, explosionSpawnTransform.position, Quaternion.identity);
    }


   
}
