using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomColorComponent : MonoBehaviour
{
    [SerializeField] private List<Color> colors;
    private void Awake()
    {
        SetRandomColor();
        Debug.Log("set random color");
    }


    // private void OnValidate()
    // {
    //     transform.position = selectionPanelPointer.pointingElement.transform.position + offset;
    // }

    private void SetRandomColor()
    {
        Color randomColor;

        
        if (colors != null)
        {
            
        }
        int red = Random.Range(0, 256);
        int blue = Random.Range(0, 256);
        int green = Random.Range(0, 256);
        randomColor = new Color(red, green, blue);
        GetComponent<SpriteRenderer>().color = randomColor;
    }
    

}