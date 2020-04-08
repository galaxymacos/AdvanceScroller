using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ChangeTextAlphaOnTrigger: MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    [SerializeField] private float alphaDecreaseSpeed = 1f;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void Trigger()
    {
        textMesh.alpha = 1;
        
    }

    private void Update()
    {
        if (textMesh.alpha > 0)
        {
            textMesh.alpha -= Time.deltaTime * alphaDecreaseSpeed;
        }
    }
}