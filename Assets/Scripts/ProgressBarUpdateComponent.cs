using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUpdateComponent : MonoBehaviour
{
    [SerializeField] private LoadSceneOnTrigger loadSceneOnTrigger;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        loadSceneOnTrigger.onLoadingPercentageUpdated += UpdateValue;
    }

    private void OnDestroy()
    {
        loadSceneOnTrigger.onLoadingPercentageUpdated -= UpdateValue;
    }

    private void UpdateValue(float obj)
    {
        slider.value = Mathf.Clamp01(obj);
    }


}
