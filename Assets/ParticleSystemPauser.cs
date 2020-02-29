using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemPauser : MonoBehaviour ,IPauseable
{
    private bool isPausing;
    [SerializeField]
    private ParticleSystem rainGenerator;
    

    


    public void Pause()
    {
        if (isPausing)
        {
            print("rain wants to stop");
            return;
        }
        rainGenerator.Pause();

        isPausing = true;
    }

    public void UnPause()
    {
        if (!isPausing)
        {
            print("rain wants to rain");
            return;
        }
        rainGenerator.Play();

        isPausing = false;
    }

   
    
}
