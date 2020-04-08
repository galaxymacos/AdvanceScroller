using System;
using UnityEngine;
using UnityEngine.Events;

public class ResetByVelocity : MonoBehaviour
{
    [SerializeField] private float MaximumResetVelocity = 1;
    [SerializeField] private float resetTime = 0.2f;
    public UnityEvent onReset;
    private float resetCounter;
    private bool isCounting=>resetCounter>0;
    
    private Rigidbody2D rb;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Trigger()
    {
        onReset?.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(rb.velocity.magnitude) < MaximumResetVelocity && !isCounting)
        {
            resetCounter = resetTime;
        }
        

        if (isCounting)
        {
            if (rb.velocity.magnitude > MaximumResetVelocity)
            {
                resetCounter = resetTime;
            }
            
            if (resetCounter > Mathf.Epsilon)
            {
                resetCounter -= Time.deltaTime;
                if (resetCounter <= Mathf.Epsilon)
                {
                    Trigger();
                }
            }
        }
    }

}