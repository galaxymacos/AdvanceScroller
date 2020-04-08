using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ComboGaugeUI : MonoBehaviour
{
    private PlayerCharacter owner;
    private ComboGauge comboGauge;
    // [SerializeField] private TextMeshProUGUI textMesh;
    private bool hasSetup;
    // [SerializeField] private float comboGaugeDecreaseSpeed;
    private PlayerPanel playerPanel;
    // private float alphaInFloat;

    public UnityEvent onComboAdded;
    public event Action<ComboGauge.ComboGaugeEventArgs> onComboAddedAction;
    public UnityEvent onComboBreak;
    public event Action<ComboGauge.ComboGaugeEventArgs> onComboBreakAction;

    private void Awake()
    {
        playerPanel = GetComponentInParent<PlayerPanel>();
        playerPanel.onPlayerSetupFinish += Setup;
    }

    private void Setup()
    {
        hasSetup = true;
        owner = playerPanel.player;
        comboGauge = owner.GetComponent<ComboGauge>();
        // comboGauge.onComboAdded += UpdateComboUI;
        // comboGauge.onComboBreak += ComboDisappear;
        comboGauge.onComboAdded += CallComboAddedEvent;
        comboGauge.onComboBreak += CallComboBreakEvent;
        // comboGaugeDecreaseSpeed = 1 / comboGauge.TimeBeforeComboBreak;
        // SetTransparency(0);
    }

    private void CallComboAddedEvent(ComboGauge.ComboGaugeEventArgs comboGaugeEventArgs)
    {
        onComboAddedAction?.Invoke(comboGaugeEventArgs);
        onComboAdded?.Invoke();
    }
    private void CallComboBreakEvent(ComboGauge.ComboGaugeEventArgs comboGaugeEventArgs)
    {
        onComboBreakAction?.Invoke(comboGaugeEventArgs);
        onComboBreak?.Invoke();
    }


    private void OnDestroy()
    {
        if (hasSetup)
        {
            // comboGauge.onComboAdded -= UpdateComboUI;
            comboGauge.onComboAdded -= CallComboAddedEvent;
            comboGauge.onComboBreak -= CallComboBreakEvent;
            
            // comboGauge.onComboBreak -= ComboDisappear;
        }
    }
    
    

    // private void UpdateComboUI()
    // {
        // SetTransparency(1);
        // textMesh.text = comboGauge.currentComboNum.ToString();
    // }

    // private void SetTransparency(float alpha)
    // {
        // alphaInFloat = alpha;
    // }

    // private void Update()
    // {
        
        // if (alphaInFloat > 0)
        // {
            // alphaInFloat -= Time.deltaTime * comboGaugeDecreaseSpeed;
        // }
        
        // textMesh.alpha = alphaInFloat;
    // }

    // private void ComboDisappear()
    // {
    // }
}