using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightingManager : MonoBehaviour
{
    private Dictionary<Light2D, float> lightsAndIntensity;

    public static LightingManager instance;

    private bool isLightOff;
    public bool islightTurningOn;

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
    }

    public void TurnOffAllLights()
    {
        print("turning off all lights");
        if (isLightOff) return;
        isLightOff = true;
        
        lightsAndIntensity = new Dictionary<Light2D, float>();
        Light2D[] lights = FindObjectsOfType<Light2D>();
        foreach (var light in lights)
        {
            lightsAndIntensity.Add(light, light.intensity);
            light.intensity = 0;
        }
    }

    private void Update()
    {
        if (islightTurningOn)
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
                islightTurningOn = false;
            }
            
        }
    }

    public void TurnOnAllLights()
    {
        print("turning on all lights");

        if (!isLightOff) return;
        
        isLightOff = false;
        islightTurningOn = true;

        
    }
}
