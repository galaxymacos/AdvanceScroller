using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundTrackPlayer : MonoBehaviour
{

    [SerializeField] private List<SoundTrackObject> soundTrackObjects;

    public static SoundTrackPlayer instance;
    
    [Serializable]
    public class SoundTrackObject
    {
        public int sceneIndex;
        public AudioType audioType;
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        
        SceneManager.activeSceneChanged += ChangeBgm;
    }
    
    private void ChangeBgm(Scene oldScene, Scene newScene)
    {
        print($"Load new scene with index {newScene.buildIndex}");
        int newSceneIndex = newScene.buildIndex;
        int oldSceneIndex = oldScene.buildIndex;

        AudioType oldAudioType = AudioType.None;
        AudioType newAudioType = AudioType.None;
        foreach (SoundTrackObject soundTrackObject in soundTrackObjects)
        {
            if (soundTrackObject.sceneIndex == newSceneIndex)
            {
                newAudioType = soundTrackObject.audioType;
            }
            if (soundTrackObject.sceneIndex == oldSceneIndex)
            {
                oldAudioType = soundTrackObject.audioType;
            }
        }

        if (oldAudioType != AudioType.None)
        {
            AudioController.instance.StopAudio(oldAudioType);
        }

        if (newAudioType != AudioType.None)
        {
            AudioController.instance.PlayAudio(newAudioType, true, 0, true);
        }
        
    }
}
