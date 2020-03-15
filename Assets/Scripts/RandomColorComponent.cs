using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomColorComponent : MonoBehaviour
{
    private void Awake()
    {
        SetRandomColor();
        
    }

    
    // private void OnValidate()
    // {
    //     transform.position = selectionPanelPointer.pointingElement.transform.position + offset;
    // }

    private void SetRandomColor()
    {
        GetComponent<SpriteRenderer>().color = RandomColorAssigner.instance.GenerateRandomColorNonRepet();
    }
    

}