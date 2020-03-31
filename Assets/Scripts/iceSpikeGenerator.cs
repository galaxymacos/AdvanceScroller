using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceSpikeGenerator : MonoBehaviour
{

    [SerializeField] Transform[] spikePositions;
    private float timeLeftForSpikeGeneration;
    [SerializeField] private float timeCircleForIceSpike = 5;
    [SerializeField] Transform iceSpike;
 
    private void Start()
    {
        timeLeftForSpikeGeneration = timeCircleForIceSpike;
        
        
    }

    private void Update()
    {
        Generator();
    }


    void Generator()
    {
        timeLeftForSpikeGeneration += -1 * Time.deltaTime;
        int Rn = Random.Range(0, spikePositions.Length);
        
        if (timeLeftForSpikeGeneration <= 0)
        {
            Transform newIceSpike =  Instantiate(iceSpike, spikePositions[Rn].transform.position,
                spikePositions[Rn].transform.rotation);
            DestroyObject(newIceSpike);
            TimesControl();
        }
 
    }
    //Generate multiple icespikes onec upon a time
    void TimesControl()
    {
        int RandomChance = Random.Range(0, 100);
        
        if (RandomChance <= 30)
        {
            timeCircleForIceSpike = 0.1f;
           
        }
        else if (RandomChance > 50f & RandomChance <= 99)
        {
            timeCircleForIceSpike = 0.3f;
           
        }
        else
        {
            timeLeftForSpikeGeneration = 5f;
           
        }
    }

}
