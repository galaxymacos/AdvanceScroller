using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionPanelPointer))]
public class PanelPositionComponent : MonoBehaviour
{
    public Vector3 offset;
    private SelectionPanelPointer selectionPanelPointer;

    private void Awake()
    {
        selectionPanelPointer = GetComponent<SelectionPanelPointer>();
    }

    // private void OnValidate()
    // {
    //     transform.position = selectionPanelPointer.pointingElement.transform.position + offset;
    // }

    private void Update()
    {
        transform.position = selectionPanelPointer.pointingElement.transform.position + offset;

    }
}
