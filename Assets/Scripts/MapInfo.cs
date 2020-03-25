using System.Collections.Generic;
using UnityEngine;

public class MapInfo: MonoBehaviour
{
    public static MapInfo instance;
    
    public Transform topLeftBoundary;
    public Transform topRightBoundary;
    public Transform bottomLeftBoundary;
    public Transform bottomRightBoundary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public Vector3 RandomLouTianPosition()
    {
        Vector3 startPosition = new Vector3(topLeftBoundary.position.x + (topRightBoundary.position.x - topLeftBoundary.position.x)*Random.Range(0f,1f), (topRightBoundary.position.y + topLeftBoundary.position.y)/2,0);
        print(startPosition);
        var result = Physics2D.Raycast(startPosition, Vector3.down, 200, LayerInfo.WhatIsGround);

        if (result.collider == null)
        {
            Debug.LogError("Didn't find ground collider ");
        }

        return result.point;
    }
}