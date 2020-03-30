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
        string lightningSound = "Lightning";
        InfiniteSoundPlayer.instance.PlayAudio(lightningSound.GetAudioType());
    }
    
    // Animation event
    public void SpawnLightningAfterEffect()
    {
        Instantiate(explosion, explosionSpawnTransform.position, Quaternion.identity);
    }


   
}
