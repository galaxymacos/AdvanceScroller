using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSoundPlayer : MonoBehaviour
{
    public List<AudioObject> audioObjects;

    public static InfiniteSoundPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayAudio(AudioType type)
    {
        print("play infinite sound");
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        foreach (AudioObject audioObject in audioObjects)
        {
            if (audioObject.type == type)
            {
                audioSource.PlayOneShot(audioObject.clip);
                Destroy(audioSource, 5);
            }
        }
    }
}
