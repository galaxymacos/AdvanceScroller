using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditEdgeDetector : MonoBehaviour
{
    [SerializeField] private BanditEventSystem eventSystem;

    public bool wasOnGrounded;

    private void Update()
    { 
        
        Collider2D result = Physics2D.OverlapCircle(transform.position, 0.1f, LayerInfo.WhatIsGround);
        
        if (result == null)
        {
            if (wasOnGrounded)
            {
                eventSystem.GoNearEdge();
            }
        }

        wasOnGrounded = result != null;
    }
    
    
}
