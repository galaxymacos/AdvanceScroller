using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboGaugeTextColorChanger : MonoBehaviour
{
    [SerializeField] private ComboGaugeUI comboGaugeUI;
    [SerializeField] private Texture rainbowSprite;
    private TextMeshProUGUI textMesh;
    private Material mat;
    private void Awake()
    {
        comboGaugeUI.onComboAddedAction += UpdateText;
        textMesh = GetComponent<TextMeshProUGUI>();
        mat = textMesh.material;
    }

    private void OnDestroy()
    {
        comboGaugeUI.onComboAddedAction -= UpdateText;
    }

    private void UpdateText(ComboGauge.ComboGaugeEventArgs obj)
    {
        if (obj.comboNum <= 3)
        {
            mat.SetTexture(ShaderUtilities.ID_FaceTex, null);
            textMesh.color = Color.yellow;
        }
        else if (obj.comboNum <= 6)
        {
            textMesh.color = Color.red;
        }
        else if (obj.comboNum <= 9)
        {
            mat.SetTexture(ShaderUtilities.ID_FaceTex, rainbowSprite);
        }
    }
}
