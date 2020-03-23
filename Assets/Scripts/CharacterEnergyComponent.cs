﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnergyComponent : MonoBehaviour
{
    [HideInInspector] public float currentEnergy;
    public float maxEnergy = 100;
    public float recoverSpeed = 10;
    public bool IsFull => Math.Abs(maxEnergy - currentEnergy) < Mathf.Epsilon;

    public FloatAction onEnergyChanged;

    private void Awake()
    {
        currentEnergy = maxEnergy;
    }

    public bool Consume(float amount)
    {
        if (currentEnergy - amount < 0)
        {
            return false;
        }
        currentEnergy = Mathf.Clamp(currentEnergy-amount, 0,100);
        
        onEnergyChanged?.Invoke(currentEnergy);
        return true;
    }

    public bool Check(float amount)
    {
        return !(currentEnergy - amount < 0);
    }

    private void Update()
    {
        Recover();
    }

    private void Recover()
    {
        currentEnergy += recoverSpeed*Time.deltaTime;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, 100);
        onEnergyChanged?.Invoke(currentEnergy);
    }
}
