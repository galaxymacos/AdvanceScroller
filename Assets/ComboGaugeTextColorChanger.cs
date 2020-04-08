using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ComboGaugeTextColorChanger : MonoBehaviour
{
    [SerializeField] private ComboGaugeUI comboGaugeUI;
    [SerializeField] private Texture2D rainbowSprite;
    private TextMeshProUGUI textMesh;
    private Material mat;
    private bool rainbowColorLooping;

    private float lowestOffsetX = 0;
    private float highestOffsetX = 0.6f;
    private float offSetIncreaseSpeed = 1f;
    private float currentOffsetX;
    private bool offsetIncreasing = true;
    
    private Tweener rainbowEffectTweener;

    
    private void Awake()
    {
        comboGaugeUI.onComboAddedAction += UpdateText;
        textMesh = GetComponent<TextMeshProUGUI>();
        mat = textMesh.fontMaterial;
    }

    private void Update()
    {
        if (rainbowColorLooping)
        {


            if (offsetIncreasing)
            {
                if (currentOffsetX<highestOffsetX)
                {
                    currentOffsetX += offSetIncreaseSpeed*Time.deltaTime;
                    if (currentOffsetX >= highestOffsetX)
                    {
                        offsetIncreasing = false;
                    }
                }
            }
            else
            {
                if (currentOffsetX>lowestOffsetX)
                {
                    currentOffsetX -= offSetIncreaseSpeed*Time.deltaTime;
                    if (currentOffsetX <= lowestOffsetX)
                    {
                        offsetIncreasing = true;
                    }
                }

            }

            mat.SetFloat(ShaderUtilities.ID_FaceDilate,currentOffsetX);

        }
    }

    private void OnDestroy()
    {
        comboGaugeUI.onComboAddedAction -= UpdateText;
    }

    private void UpdateText(ComboGauge.ComboGaugeEventArgs obj)
    {
        transform.localScale = new Vector3(1, 1, 1);
        if (obj.comboNum <= 3)
        {
            
            transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f).OnComplete(() => transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            mat.SetTexture(ShaderUtilities.ID_FaceTex, null);
            textMesh.color = Color.yellow;
            StopRainbowLoop();
        }
        else if (obj.comboNum <= 6)
        {
            transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f).OnComplete(() => transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            transform.DORotateQuaternion(Quaternion.Euler(0, 0, 45), 0.1f).OnComplete(()=>transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 0.1f));
            textMesh.color = Color.red;
        }
        else if (obj.comboNum <= 9)
        {
            transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f).OnComplete(() => transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            transform.DORotateQuaternion(Quaternion.Euler(0, 0, 60), 0.1f).OnComplete(()=>transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 0.1f));
            textMesh.color = Color.white;
            mat.SetTexture(ShaderUtilities.ID_FaceTex, rainbowSprite);
        }

        if (obj.comboNum >= 10)
        {
            StartRainbowColor();
        }
    }

    private void StartRainbowColor()
    {
        currentOffsetX = lowestOffsetX;
        offsetIncreasing = true;
        mat.SetFloat(ShaderUtilities.ID_VertexOffsetX,currentOffsetX);
        rainbowColorLooping = true;
        rainbowEffectTweener = transform.DOScale(new Vector3(2.2f, 2.2f, 2.2f), 0.1f).OnComplete(() => transform.DOScale(new Vector3(1, 1, 1), 0.1f));
    }

    private void StopRainbowLoop()
    {
        mat.SetFloat(ShaderUtilities.ID_FaceDilate,0);
        rainbowColorLooping = false;
    }
    
    
}
