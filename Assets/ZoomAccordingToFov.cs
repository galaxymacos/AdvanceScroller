using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAccordingToFov : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public float CameraSize => cam.orthographicSize;


    private MultipleTargetCamera multiTargetCamera;
    
    private float originalFovRatio;

    public float maxScale = 2f;
    public float minScale = 1f;


    private float maxZoom;
    private float minZoom;
    private float currentZoom;
    private float ratio;
    private void Awake()
    {
        print(cam.orthographicSize);
        print(transform.localScale.x);
        originalFovRatio = cam.orthographicSize/transform.localScale.x;
        
        multiTargetCamera = GetComponentInParent<MultipleTargetCamera>();
        maxZoom = multiTargetCamera.maxZoom;
        minZoom = multiTargetCamera.minZoom;

        
       

    }
    
    // Update is called once per frame
    void Update()
    {
        
        currentZoom = cam.orthographicSize;
        ratio = (currentZoom - minZoom) / (maxZoom - minZoom - (minZoom - minZoom)); 
        float targetScale = minScale + (maxScale - minScale) * ratio;
        transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        // transform.localScale = new Vector3(cam.orthographicSize / originalFovRatio,cam.orthographicSize / originalFovRatio,cam.orthographicSize / originalFovRatio);
    }
}
