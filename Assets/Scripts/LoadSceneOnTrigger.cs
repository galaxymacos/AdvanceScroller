using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    public string sceneToLoad;

    [SerializeField] private bool loadCurrentScene;

    private bool hasTriggered;
    public void Trigger()
    {

        if (hasTriggered) return;
        hasTriggered = true;
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