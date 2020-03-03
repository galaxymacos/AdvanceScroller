using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTurningOnState:IState
{
    public void Tick()
    {

        bool hasAllLightTurnOn = true;
        foreach (KeyValuePair<Light2D,float> lightAndIntensity in LightingManager.instance.lightsAndIntensity)
        {
            lightAndIntensity.Key.intensity = Mathf.Lerp(lightAndIntensity.Key.intensity, lightAndIntensity.Value, 0.02f);
            if (Mathf.Abs(lightAndIntensity.Key.intensity - lightAndIntensity.Value) < 0.03f)
            {
                lightAndIntensity.Key.intensity = lightAndIntensity.Value;
            }
        }
        foreach (KeyValuePair<Light2D,float> lightAndIntensity in LightingManager.instance.lightsAndIntensity)
        {
            if (Math.Abs(lightAndIntensity.Key.intensity - lightAndIntensity.Value) > 0.03f)
            {
                hasAllLightTurnOn = false;
            }
        }

        if (hasAllLightTurnOn)
        {
            // Transfer to lightOnState
        }
    }

    public void OnEnter()
    {
        Debug.Log("Lighting turning on");
        LightingManager.instance.lightOnTrigger = false;
        LightingManager.instance.lightOffTrigger = false;
    }

    public void OnExit()
    {
    }
}