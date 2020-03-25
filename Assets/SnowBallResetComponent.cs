using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SnowballEventSystem))]
public class SnowBallResetComponent : MonoBehaviour
{
    private float resetTime = 0.2f;
    private SnowballEventSystem eventSystem;
    private float resetCounter;
    private bool isCounting;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        eventSystem = GetComponent<SnowballEventSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(rb.velocity.magnitude) < Mathf.Epsilon && !isCounting)
        {
            isCounting = true;
            resetCounter = resetTime;
        }
        

        if (isCounting)
        {
            if (rb.velocity.magnitude > 0)
            {
                resetCounter = resetTime;
            }
            
            if (resetCounter > Mathf.Epsilon)
            {
                resetCounter -= Time.deltaTime;
                if (resetCounter <= 0)
                {
                    eventSystem.SnowballReset();
                }
            }
        }
    }

}
