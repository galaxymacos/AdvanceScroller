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
            WhatIsPlayer = whatIsPlayer;
            WhatIsLadder = whatIsLadder;

        }
        else
        {
            Destroy(this);
        }
    }

    public static LayerMask WhatIsGround;
    public static LayerMask WhatIsWall;
    public static LayerMask WhatIsPlayer;
    public static LayerMask WhatIsLadder;
    
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsLadder;
}