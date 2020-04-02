using TMPro;
using UnityEngine;

public class FloatingTextSpawner : MonoBehaviour
{
    public Transform canvas;
    [SerializeField] private GameObject textObjectPrefab;
    public static FloatingTextSpawner instance;
    
    private Camera cam;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        cam = Camera.main;
    }

    public void SpawnText(string text, Vector3 worldLocation)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(worldLocation);
        var textObject = Instantiate(textObjectPrefab, canvas);
        textObject.transform.position = screenPos;
        textObject.GetComponent<TextMeshProUGUI>().text = text;
        Debug.Log("Spawn text");
    }
}
