using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboGaugeText : MonoBehaviour
{
    [SerializeField] private ComboGaugeUI comboGaugeUI;
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        comboGaugeUI.onComboAddedAction += UpdateText;
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void OnDestroy()
    {
        comboGaugeUI.onComboAddedAction -= UpdateText;
    }

    private void UpdateText(ComboGauge.ComboGaugeEventArgs obj)
    {
        textMesh.text = $"Hit {obj.comboNum.ToString()}";
    }
}
