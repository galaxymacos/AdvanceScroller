using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    public string sceneToLoad;

    public UnityEvent onSceneChangeTo;
    private void Awake()
    {
        

        SceneManager.activeSceneChanged += Trigger;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged += Trigger;
    }

    private void Trigger(Scene arg0, Scene arg1)
    {
        if (sceneToLoad == arg1.name)
        {
            onSceneChangeTo?.Invoke();
        }
    }
}
