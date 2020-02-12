using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyComponent : MonoBehaviour
{
    private float energy;
    public float maxEnergy = 100;
    public float recoverSpeed = 10;

    public FloatAction onEnergyChanged;

    private void Awake()
    {
        energy = maxEnergy;
    }

    public bool Consume(int amount)
    {
        if (energy - amount < 0)
        {
            return false;
        }
        energy = Mathf.Clamp(energy-amount, 0,100);
        
        onEnergyChanged?.Invoke(energy);
        return true;
    }

    private void Update()
    {
        Recover();
    }

    public void Recover()
    {
        energy += recoverSpeed*Time.deltaTime;
        energy = Mathf.Clamp(energy, 0, 100);
        onEnergyChanged?.Invoke(energy);
    }
}
