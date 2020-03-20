﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttackComponent : CollisionDetector, IAttackComponent
{
    // private bool hasDealDamaged;
    // private bool isRunning;
    public DamageData damageData;
    

    public List<GameObject> objectsHasProcessed = new List<GameObject>();



    private bool DealDamageToSingleTarget(GameObject gameObjectCollided)
    {
        bool hitTarget = false;
        if (gameObjectCollided != transform.gameObject && gameObjectCollided != null)
        {
            if (gameObjectCollided.GetComponent<PlayerCharacter>() != null)
            {
                if (!objectsHasProcessed.Contains(gameObjectCollided))
                {
                    DamageReceiver damageReceiver = gameObjectCollided.GetComponent<DamageReceiver>(); 
                    if ( damageReceiver != null)
                    {
                        hitTarget = true;
                        damageReceiver.Analyze(damageData, transform.root);
                        objectsHasProcessed.Add(gameObjectCollided);
                    }
                }
            }
        }

        if (hitTarget)
        {
            if (!string.IsNullOrEmpty(damageData.hitSound))
            {
                AudioController.instance.PlayAudio(AudioTypeConverter.ToAudioType(damageData.hitSound));
            }
        }
        return hitTarget;
    }

    public bool Execute()
    {
        objectsHasProcessed = new List<GameObject>();
        // isRunning = true;
        bool hitTarget = false;
        foreach (GameObject objectCollided in ObjectsInCollision)
        {
            if (DealDamageToSingleTarget(objectCollided))
            {
                hitTarget = true;
            }
        }

        return hitTarget;
    }




    // public void StopDetectTargetManually()
    // {
        // isRunning = false;
        
    // }
}

public static class AudioTypeConverter
{
    public static AudioType ToAudioType(string audioInString)
    {
        bool parseResult = Enum.TryParse(audioInString, true, out AudioType result);
        if (!parseResult)
        {
            Debug.LogError($"Can't find the audio type with the name {audioInString}");
        }
        return result;
    }
   
}