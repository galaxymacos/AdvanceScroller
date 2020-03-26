using System.Collections.Generic;
using UnityEngine;

public class MapInfo: MonoBehaviour
{
    public static MapInfo instance;

    public Transform topLeftBoundary;
    public Transform topRightBoundary;
    public Transform bottomLeftBoundary;
    public Transform bottomRightBoundary;

    public MapInfoInquirer Inquirer; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Inquirer = new MapInfoInquirer(this);
    }

    public class MapInfoInquirer
    {
        private readonly MapInfo mapInfo;

        public MapInfoInquirer(MapInfo mapInfo)
        {
            this.mapInfo = mapInfo;
        }

        public float GetWeight => mapInfo.topRightBoundary.position.x - mapInfo.topLeftBoundary.position.x;
        public float GetHeight => mapInfo.topLeftBoundary.position.y - mapInfo.bottomLeftBoundary.position.y;

        public Vector2 RandomPointInMap()
        {
            float randomX = mapInfo.topLeftBoundary.position.x + Random.Range(0, GetWeight);
            float randomY = mapInfo.bottomLeftBoundary.position.y + Random.Range(0, GetHeight);
            return new Vector2(randomX, randomY);
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