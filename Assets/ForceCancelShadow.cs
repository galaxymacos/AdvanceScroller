using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCancelShadow : MonoBehaviour
{
    public SpriteRenderer sr;
    public static Action<ForceCancelShadow> onForceCancelshadowCreated;
    // Start is called before the first frame update
    void Start()
    {
        onForceCancelshadowCreated?.Invoke(this);
    }
    
    
}
