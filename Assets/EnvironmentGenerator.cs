using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentGenerator : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem TargetParticleSystem;
    [SerializeField]
    Text CountDownTimer;
    private float timeLeftInTimeCircle = 0;
    [SerializeField] private float TimeCircle = 20;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftInTimeCircle = TimeCircle;
    }

    // Update is called once per frame
    void Update()
    {
        particleSystemValueControl();
    }
    private void particleSystemValueControl()
    {
        
        var ps = TargetParticleSystem.GetComponent<ParticleSystem>();
        var vel = ps.forceOverLifetime;

        timeLeftInTimeCircle -= 1 * Time.deltaTime;
        CountDownTimer.text = timeLeftInTimeCircle.ToString("F0");
        if (timeLeftInTimeCircle <= TimeCircle && timeLeftInTimeCircle >= TimeCircle / 2)
        {
            vel.x = - 10; 
        }
        else if (timeLeftInTimeCircle >0  && timeLeftInTimeCircle <= TimeCircle / 2)
        {
            vel.x = 10;
        }
        else 
        {
            timeLeftInTimeCircle = TimeCircle;
        }

    }

}
