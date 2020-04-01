using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public void Trigger()
    {
        Destroy(gameObject);
    }
}