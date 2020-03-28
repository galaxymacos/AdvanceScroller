using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallResetComponent : MonoBehaviour
{
    private float resetTime = 0.2f;
    private float resetCounter;
    private bool isCounting=>resetCounter>0;
    private float resetCountStartVelocity = 1;
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(rb.velocity.magnitude) < resetCountStartVelocity && !isCounting)
        {
            resetCounter = resetTime;
        }
        

        if (isCounting)
        {
            if (rb.velocity.magnitude > resetCountStartVelocity)
            {
                resetCounter = resetTime;
            }
            
            if (resetCounter > Mathf.Epsilon)
            {
                resetCounter -= Time.deltaTime;
                if (resetCounter <= Mathf.Epsilon)
                {   
                    print("resetting the owner");
                }
            }
        }
    }
}
