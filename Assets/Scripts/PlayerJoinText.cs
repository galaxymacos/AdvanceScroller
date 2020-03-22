using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerJoinText : MonoBehaviour
{
    [SerializeField] private int playerIndexToDetect;
    private TextMeshPro text;

    [SerializeField] private float flashInterval = 1f;
    private float flashIntervalCounter;
    
    
    public bool detectPlayer => PointerCounter.PointerNum >= playerIndexToDetect;

    private void Awake()
    {
        flashIntervalCounter = flashInterval;
        if (flashInterval <= 0)
        {
            Debug.LogError("Flash timer should be greater than 0");
        }
        text = GetComponent<TextMeshPro>();
    }


    // Update is called once per frame
    void Update()
    {
        if (detectPlayer)
        {
            text.enabled = false;
        }
        else
        {
            FlashUpdate();
        }
    }

    private void FlashUpdate()
    {
        flashIntervalCounter -= Time.deltaTime;
        if (flashIntervalCounter <= 0)
        {
            flashIntervalCounter = flashInterval;
            ToggleVisibility();
        }
    }

    private void ToggleVisibility()
    {
        text.enabled = !text.enabled;
    }
}
