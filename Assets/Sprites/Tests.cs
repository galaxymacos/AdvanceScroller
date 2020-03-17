using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    private void Awake()
    {
        print($"There are {PointerCounter.PointerNum} pointers in game");
    }
}
