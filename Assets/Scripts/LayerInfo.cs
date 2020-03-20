using System;
using UnityEngine;

public class LayerInfo: MonoBehaviour
{
    public static LayerInfo instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            WhatIsGround = whatIsGround;
            WhatIsWall = whatIsWall;
        }
        else
        {
            Destroy(this);
        }
    }

    public static LayerMask WhatIsGround;
    public static LayerMask WhatIsWall;
    
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;
    
}