using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    private void Awake()
    {
        Pause.onPause += PauseAll;
        Pause.onUnpause += UnpauseAll;
    }

    private void OnDestroy()
    {
        Pause.onPause -= PauseAll;
        Pause.onUnpause -= UnpauseAll;
    }

    public void PauseAll()
    {
        var scripts = FindObjectsOfType<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script is IPauseable pauseable)
            {
                pauseable.Pause();
            }
        }
    }

    public void UnpauseAll()
    {
        var scripts = Object.FindObjectsOfType<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script is IPauseable pauseable)
            {
                pauseable.UnPause();
            }
        }
    }
}
