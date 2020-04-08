using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class JumpEffectOnStart: MonoBehaviour
{
    [SerializeField] private Vector3 jumpOffset = new Vector3(0f, 100f);
    private TextMeshProUGUI textMesh;
    private bool hasJumped;
    private void Update()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        // if (!hasJumped && GetComponent<RectTransform>()!=null)
        // {
            // hasJumped = true;
            // GetComponent<RectTransform>().(transform.position+jumpOffset, 1f);
        // }
        
        GetComponent<RectTransform>()?.Translate(0,100*Time.deltaTime,0);
        textMesh.alpha -= Time.deltaTime * 0.3f;
        textMesh.alpha = Mathf.Clamp(  textMesh.alpha, 0, 1);


    }
}