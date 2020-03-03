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

    private LightingManagerState state;
    
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
        state = LightingManagerState.LightingOn;
    }

    public void TurnOffAllLights()
    {

        if (state == LightingManagerState.LightingOn)
        {
            lightsAndIntensity = new Dictionary<Light2D, float>();
            Light2D[] lights = FindObjectsOfType<Light2D>();
            foreach (var light in lights)
            {
                lightsAndIntensity.Add(light, light.intensity);
                light.intensity = 0;
            }
        }
        else if (state == LightingManagerState.LightingTurningOn)
        {
            foreach (Light2D light2D in lightsAndIntensity.Keys)
            {
                light2D.intensity = 0;
            }
        }
        
        if (state == LightingManagerState.LightingOn || state == LightingManagerState.LightingTurningOn)
        {
            state = LightingManagerState.LightingOff;
        }
        

        
    }

    private void Update()
    {
        if (state == LightingManagerState.LightingTurningOn)
        {
            bool hasAllLightTurnOn = true;
            foreach (KeyValuePair<Light2D,float> lightAndIntensity in lightsAndIntensity)
            {
                lightAndIntensity.Key.intensity = Mathf.Lerp(lightAndIntensity.Key.intensity, lightAndIntensity.Value, 0.02f);
                if (Mathf.Abs(lightAndIntensity.Key.intensity - lightAndIntensity.Value) < 0.03f)
                {
                    lightAndIntensity.Key.intensity = lightAndIntensity.Value;
                }
            }
            foreach (KeyValuePair<Light2D,float> lightAndIntensity in lightsAndIntensity)
            {
                if (Math.Abs(lightAndIntensity.Key.intensity - lightAndIntensity.Value) > 0.03f)
                {
                    hasAllLightTurnOn = false;
                }
            }

            if (hasAllLightTurnOn)
            {
                // islightTurningOn = false;
                state = LightingManagerState.LightingOn;
            }
            
            
        }
        
    }

    public void TurnOnAllLights()
    {
        // print("turning on all lights");
        //
        // if (!isLightOff) return;
        //
        // isLightOff = false;
        // islightTurningOn = true;
        state = LightingManagerState.LightingTurningOn;

    }
}

public enum LightingManagerState
{
    LightingOn, LightingOff, LightingTurningOn
}


