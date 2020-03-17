using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleTimeSkipper : MonoBehaviour
{
    private ParticleSystem ps;
    public float timeToSkip = 1f;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        ps.playbackSpeed = 100f;
    }
    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.time > timeToSkip)
        {
            ps.playbackSpeed = 1f;
        }
    }
}
