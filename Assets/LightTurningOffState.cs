using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTurningOffState:IState
{
    public void Tick()
    {
        // if (state == LightingManagerState.LightingOn)
        // { 
            
        // }
        
        
        foreach (KeyValuePair<Light2D,float> lightAndIntensity in LightingManager.instance.lightsAndIntensity)
        {
            lightAndIntensity.Key.intensity = Mathf.Lerp(lightAndIntensity.Key.intensity, 0, 0.02f);
            if (lightAndIntensity.Key.intensity < 0.03f)
            {
                lightAndIntensity.Key.intensity = 0;
            }
        }
        
        bool hasAllLightTurnOff = true;
        foreach (KeyValuePair<Light2D,float> lightAndIntensity in LightingManager.instance.lightsAndIntensity)
        {
            if (lightAndIntensity.Key.intensity> 0.03f)
            {
                hasAllLightTurnOff = false;
            }
        }

        if (hasAllLightTurnOff)
        {
            // Transfer to lightOnState
        }
    }

    public void OnEnter()
    {
        LightingManager.instance.lightOnTrigger = false;
        LightingManager.instance.lightOffTrigger = false;
        Light2D[] lights = Object.FindObjectsOfType<Light2D>();

        if (LightingManager.instance.hasLightFullyRecovered)
        {
            LightingManager.instance.lightsAndIntensity = new Dictionary<Light2D, float>();
            foreach (var light in lights)
            {
                LightingManager.instance.lightsAndIntensity.Add(light, light.intensity);
            }
            LightingManager.instance.hasLightFullyRecovered = false;
        }
        
        foreach (var light in lights)
        {
            light.intensity = 0;
        }

        
        
    }

    public void OnExit()
    {
    }
}