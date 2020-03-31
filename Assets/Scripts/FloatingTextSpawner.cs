using TMPro;
using UnityEngine;

public class FloatingTextSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 offsetToTransform;
    public Transform canvas;
    [SerializeField] private GameObject textObjectPrefab;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void SpawnText(string text, Transform worldLocation)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position+offsetToTransform);
        var textObject = Instantiate(textObjectPrefab, canvas);
        textObject.transform.position = screenPos;
        textObject.GetComponent<TextMeshProUGUI>().text = text;
        Debug.Log("Spawn text");
    }
}

[RequireComponent(typeof(CharacterDamageReceiver))]
public class SpawnMissTextWhenInvincible: MonoBehaviour
{
    
}