using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChangeImageAlphaOnTrigger : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ChangeAlphaTo(float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}
