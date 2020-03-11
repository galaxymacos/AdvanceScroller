using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionPointer))]
public class PanelPositionComponent : MonoBehaviour
{
    public Vector3 offset;
    private static readonly Vector3 baseOffset = new Vector3(0,-0.8f,0);
    private static readonly Vector3 increaseOffset = new Vector3(0,-0.4f,0);
    private static int layerOfIncrease = 0;
    private SelectionPointer selectionPointer;

    private void Awake()
    {
        
        selectionPointer = GetComponent<SelectionPointer>();
        selectionPointer.onSetUp += IncreaseOffset;
    }

    // private void OnValidate()
    // {
    //     transform.position = selectionPanelPointer.pointingElement.transform.position + offset;
    // }

    private void Update()
    {
        transform.position = selectionPointer.PointingElement.transform.position + offset;

    }

    private void IncreaseOffset()
    {
        offset = baseOffset + (layerOfIncrease++ * increaseOffset);
    }
}