using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Object = UnityEngine.Object;

public class LightingManager : MonoBehaviour
{
    public Dictionary<Light2D, float> lightsAndIntensity;

    public static LightingManager instance;


    public bool hasLightFullyRecovered = true;
    // State machine
    public bool lightOffTrigger;
    public bool lightOnTrigger;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // state = LightingManagerState.LightingOn;
    }

}




