using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleTimeSkipper : MonoBehaviour
{
    private ParticleSystem ps;
    public float timeToSkip = 1f;
    public bool skipFinished;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        print("the start time of the particle system is "+ps.time);
        var mainModule = ps.main;
        mainModule.simulationSpeed = 100f;
    }
    
    
    


    // // Start is called before the first frame update
    // void Start()
    // {
    //     ps.time = 1;
    // }

    // Update is called once per frame
    void Update()
    {
        if (skipFinished) return;
        
        if (ps.time > timeToSkip)
        {
            ps.time = timeToSkip;
            var mainModule = ps.main;
            mainModule.simulationSpeed = 1;
            skipFinished = true;
        }
    }
}
