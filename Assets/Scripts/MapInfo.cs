using System.Collections.Generic;
using UnityEngine;

public class MapInfo: MonoBehaviour
{
    public static MapInfo instance;
    public List<Transform> itemGeneratedPositions;

    
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
}