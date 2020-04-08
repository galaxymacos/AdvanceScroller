using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TextRandomColorOnStart : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private List<Color> colors;
    [SerializeField] private bool activateOnStart;

    private void Awake()
    {
        print("lalallaallaal");
        text = GetComponent<TextMeshProUGUI>();
        if (activateOnStart)
        {
            Trigger();
        }
    }

    public void Trigger()
    {
        text.color = colors[Random.Range(0, colors.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
