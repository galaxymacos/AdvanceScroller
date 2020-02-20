using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory : MonoBehaviour
{
    // for automatically generate a skill icon in the skill panel for each skill
    public GameObject skillComponent;
    [Tooltip("Which skill should be shown ")]
    public List<string> skillDisplayedInOrder;

    public static UIFactory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
