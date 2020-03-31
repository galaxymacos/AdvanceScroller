﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboGaugeUI : MonoBehaviour
{
    private PlayerCharacter owner;
    private ComboGauge comboGauge;
    private TextMeshProUGUI textMesh;
    private bool hasSetup;
    [SerializeField] private float comboGaugeDecreaseSpeed;
    private PlayerPanel playerPanel;
    private float alphaInFloat;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        playerPanel = GetComponentInParent<PlayerPanel>();
        playerPanel.onPlayerSetupFinish += Setup;
    }

    private void Setup()
    {
        hasSetup = true;
        owner = playerPanel.player;
        comboGauge = owner.GetComponent<ComboGauge>();
        comboGauge.onComboAdded += UpdateComboUI;
        // comboGauge.onComboBreak += ComboDisappear;
        comboGaugeDecreaseSpeed = 1 / comboGauge.TimeBeforeComboBreak;
        SetTransparency(0);
    }

    private void OnDestroy()
    {
        if (hasSetup)
        {
            comboGauge.onComboAdded -= UpdateComboUI;
            // comboGauge.onComboBreak -= ComboDisappear;
        }
    }

    private void UpdateComboUI()
    {
        SetTransparency(1);
        textMesh.text = comboGauge.currentComboNum.ToString();
    }

    private void SetTransparency(float alpha)
    {
        alphaInFloat = alpha;
    }

    private void Update()
    {
        
        if (alphaInFloat > 0)
        {
            print("alpha in float: "+alphaInFloat);
            alphaInFloat -= Time.deltaTime * comboGaugeDecreaseSpeed;
        }
        
        textMesh.alpha = alphaInFloat;
    }

    // private void ComboDisappear()
    // {
    // }
}