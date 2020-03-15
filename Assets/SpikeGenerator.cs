using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{

    [SerializeField] Transform[] spikePositions;
    private float timeLeftForSpikeGeneration;
    [SerializeField] private float timeCircleForSpike = 20;
    [SerializeField] Transform iceSpike;
    

    private void Start()
    {
        timeLeftForSpikeGeneration = timeCircleForSpike;
    }

    private void Update()
    {  
        spikeGenerator();
    }


    void spikeGenerator()
    {
        timeLeftForSpikeGeneration += -1 * Time.deltaTime;
        int Rn = Random.Range(1, spikePositions.Length);
        if (timeLeftForSpikeGeneration <= 0)
        {
            Transform newSpike =  Instantiate(iceSpike, spikePositions[Rn].transform.position, spikePositions[Rn].transform.rotation);

            print("I am generated");
            timeLeftForSpikeGeneration = timeCircleForSpike;
        }
       
        
    }

    
}
