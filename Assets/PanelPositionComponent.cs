using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionPointer))]
public class PanelPositionComponent : MonoBehaviour
{
    public Vector3 offset;
    private SelectionPointer selectionPointer;

    private void Awake()
    {
        selectionPointer = GetComponent<SelectionPointer>();
    }

    // private void OnValidate()
    // {
    //     transform.position = selectionPanelPointer.pointingElement.transform.position + offset;
    // }

    private void Update()
    {
        transform.position = selectionPointer.PointingElement.transform.position + offset;

    }
}
