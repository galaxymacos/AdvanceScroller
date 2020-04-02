using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SoundTrackPlayer : MonoBehaviour
{

    [SerializeField] private List<SoundTrackObject> soundTrackObjects;

    private int oldSceneIndex = -1;
    public static SoundTrackPlayer instance;
    
    [Serializable]
    public class SoundTrackObject
    {
        public int sceneIndex;
        public List<string> audioTypeInString;
    }
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.activeSceneChanged += ChangeBgm;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnDestroy()
    {
        print("change bgm deRegistered");
        SceneManager.activeSceneChanged -= ChangeBgm;
    }

    private void ChangeBgm(Scene oldScene, Scene newScene)
    {
        int newSceneIndex = newScene.buildIndex;
       

        AudioType oldAudioType = AudioType.None;
        AudioType newAudioType = AudioType.None;
        foreach (SoundTrackObject soundTrackObject in soundTrackObjects)
        {
            if (soundTrackObject.sceneIndex == newSceneIndex)
            {
                bool parseResult = Enum.TryParse(soundTrackObject.audioTypeInString[Random.Range(0, soundTrackObject.audioTypeInString.Count)], true, out AudioType bgmAudioType);
                if(!parseResult) Debug.LogError("can't find the bgm with the name ");
                newAudioType = bgmAudioType;
            }
            if (soundTrackObject.sceneIndex == oldSceneIndex)
            {
                bool parseResult = Enum.TryParse(soundTrackObject.audioTypeInString[Random.Range(0, soundTrackObject.audioTypeInString.Count)], true, out AudioType bgmAudioType);
                if(!parseResult) Debug.LogError("can't find the bgm with the name ");
                oldAudioType = bgmAudioType;
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

        oldSceneIndex = newSceneIndex;

    }
}
