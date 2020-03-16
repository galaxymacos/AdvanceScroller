using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionPointer))]
public class PointerPositionComponent : MonoBehaviour
{
    [SerializeField] private Vector3 baseOffset = new Vector3(0,-0.8f,0);
    [SerializeField] private Vector3 increaseOffset = new Vector3(0,-0.4f,0);
    
    private static int layerOfIncrease = 0;
    private SelectionPointer selectionPointer;
    
    // The order of creation 
    private int currentPointerIndex;

    private void Awake()
    {
        selectionPointer = GetComponent<SelectionPointer>();
        // selectionPointer.onSetUp += IncreaseOffset;
        currentPointerIndex = PointerCounter.PointerNum++;
    }

    // private void OnDestroy()
    // {
        // selectionPointer.onSetUp -= IncreaseOffset;
        // layerOfIncrease = 0;
    // }

    private void Update()
    {
        if (selectionPointer.PointingElement != null)
        {
            transform.position = selectionPointer.PointingElement.transform.position + baseOffset + increaseOffset*currentPointerIndex;
        }

    }

    
    // private void IncreaseOffset()
    // {
    //     offset = baseOffset + (layerOfIncrease++ * increaseOffset);
    // }
}