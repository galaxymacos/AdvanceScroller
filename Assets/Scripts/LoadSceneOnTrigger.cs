﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    public string sceneToLoad;

    [SerializeField] private bool loadCurrentScene;
    public void Trigger()
    {
        print("load scene trigger");
        if (loadCurrentScene)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }
    
    public void Trigger(string _sceneToLoad)
    {
        sceneToLoad = _sceneToLoad;
        Trigger();
    }
    
    
}