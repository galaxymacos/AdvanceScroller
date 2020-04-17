using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BleedDebuffIcon : MonoBehaviour
{
    private Image sr;
    private float bleedDurationCounter;

    private void Awake()
    {
        sr = GetComponent<Image>();
        sr.enabled = false;
    }
    

    

    public void Show(object sender, BuffEventArgs e)
    {
        bleedDurationCounter = e.duration;
        sr.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (bleedDurationCounter > 0)
        {
            print("bleed duration: "+bleedDurationCounter);
            bleedDurationCounter -= Time.deltaTime;
            if (bleedDurationCounter <= 0)
            {
                sr.enabled = false;
            }
        }
    }
}