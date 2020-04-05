using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    public string sceneToLoad;

    [SerializeField] private bool loadCurrentScene;

    public UnityEvent onBeforeLoading;
    public UnityEvent onLoadingAlmostFinish;
    [SerializeField] private bool requireConfirm;
    public event Action<float> onLoadingPercentageUpdated;
    private bool hasTriggered;
    public void Trigger()
    {

        if (hasTriggered) return;
        hasTriggered = true;
        onBeforeLoading?.Invoke();
        if (loadCurrentScene)
        {
            StartCoroutine(LoadingScene(SceneManager.GetActiveScene().name));
        }
        else
        {
            StartCoroutine(LoadingScene(sceneToLoad));
        }
    }

    public IEnumerator LoadingScene(string sceneNameToLoad)
    {
        Application.backgroundLoadingPriority = ThreadPriority.BelowNormal;
        var operation = SceneManager.LoadSceneAsync(sceneNameToLoad);
        operation.allowSceneActivation =     false;
        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / 0.9f);
            onLoadingPercentageUpdated?.Invoke(progress);

            if (progress >= 0.9f)
            {
                
                onLoadingAlmostFinish?.Invoke();
                onLoadingPercentageUpdated?.Invoke(1);
                if (requireConfirm)
                {
                    if (confirm)
                    {
                        operation.allowSceneActivation = true;
                    }
                }
                else
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
        // yield return new WaitForSeconds(1.5f);

    }

    private bool confirm;
    public void TriggerConfirm()
    {
        confirm = true;
    }
    
    public void Trigger(string _sceneToLoad)
    {
        sceneToLoad = _sceneToLoad;
        Trigger();
    }
    
    
}