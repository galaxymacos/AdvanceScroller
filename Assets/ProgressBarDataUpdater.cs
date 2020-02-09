using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;

public class ProgressBarDataUpdater : MonoBehaviour
{
    private ProgressBar progressBar;

    private void Awake()
    {
        progressBar = GetComponent<ProgressBar>();
    }

    public void UpdateCurrentPencent(float progress)
    {
        progressBar.currentPercent = progress;
    }
}
