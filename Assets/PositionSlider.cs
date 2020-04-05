using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSlider : MonoBehaviour
{
    public Transform startPosition;

    public Transform endPosition;

    [SerializeField] private LoadSceneOnTrigger loadSceneOnTrigger;

    private void Awake()
    {
        loadSceneOnTrigger.onLoadingPercentageUpdated += SetPosition;
    }

    private void OnDestroy()
    {
        loadSceneOnTrigger.onLoadingPercentageUpdated -= SetPosition;
    }

    public void SetPosition(float percentage)
    {
        transform.position = startPosition.position + (endPosition.position - startPosition.position) * percentage;
    }
}
