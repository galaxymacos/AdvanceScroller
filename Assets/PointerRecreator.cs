using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Activate all the pointers if any exist
/// </summary>
public class PointerRecreator : MonoBehaviour
{
    private void Start()
    {
        PointerUtil.ActivateAllPointers();
    }

}
