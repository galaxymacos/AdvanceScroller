using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemPauser : MonoBehaviour ,IPauseable
{
    private bool isPausing;
    [SerializeField]
    private ParticleSystem TargetParticleSystem;
    

    


    public void Pause()
    {
        if (isPausing)
        {
            print("rain wants to stop");
            return;
        }
        TargetParticleSystem.Pause();

        isPausing = true;
    }

    public void UnPause()
    {
        if (!isPausing)
        {
            print("rain wants to rain");
            return;
        }
        TargetParticleSystem.Play();

        isPausing = false;
    }

   
    
}
