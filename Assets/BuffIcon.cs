using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffIcon : MonoBehaviour
{
    private Image sr;
    private float duration;

    private void Awake()
    {
        sr = GetComponent<Image>();
        sr.enabled = false;
    }
    

    

    public void Show(object sender, BuffEventArgs e)
    {
        duration = e.duration;
        sr.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (duration > 0)
        {
            print("bleed duration: "+duration);
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                sr.enabled = false;
            }
        }
    }
}