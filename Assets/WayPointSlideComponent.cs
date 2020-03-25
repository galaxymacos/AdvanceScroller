using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class WayPointSlideComponent : MonoBehaviour
{
    public Transform[] wayPoints;

    private Vector3[] wayPointsPosition;

    private void Awake()
    {
        IceSlideEventSystem.onIceSlideStart += Run;
        // IceSlideEventSystem.onIceSlideEnlargeFinish += SetupWayPoints;
    }
    private void OnDestroy()
    {
        IceSlideEventSystem.onIceSlideStart -= Run;
        // IceSlideEventSystem.onIceSlideEnlargeFinish -= SetupWayPoints;
    }
    private void SetupWayPoints()
    {
        wayPointsPosition = wayPoints.Select(wp => wp.position).ToArray();
    }

    

    private void Run()
    {
        SetupWayPoints();
        transform.DOPath(wayPointsPosition, 10, PathType.CatmullRom, PathMode.Sidescroller2D).OnComplete(IceSlideEventSystem.instance.IceSlideFinish);

    }
}