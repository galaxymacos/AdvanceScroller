using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnergyComponent : MonoBehaviour
{
    [HideInInspector] public float currentEnergy;
    public float maxEnergy = 100;
    public float recoverSpeed = 10;

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

    private void Update()
    {
        Recover();
    }

    public void Recover()
    {
        currentEnergy += recoverSpeed*Time.deltaTime;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, 100);
        onEnergyChanged?.Invoke(currentEnergy);
    }
}
