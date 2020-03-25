using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlideEventSystem : MonoBehaviour
{
    public static IceSlideEventSystem instance;

    public static event Action onIceSlideStart;
    public static event Action onIceSlideFinish;
    public static event Action onIceSlideShrinkFinish;
    public static event Action onIceSlideEnlargeFinish;
    public static event Action onIceSlideDestroy;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    public void IceSlideStart()
    {
        onIceSlideStart?.Invoke();
    }
    
    public void IceSlideFinish()
    {
        onIceSlideFinish?.Invoke();
    }

    public void IceSlideDestroy()
    {
        onIceSlideDestroy?.Invoke();
    }

    public void IceSlideShrinkFinish()
    {
        onIceSlideShrinkFinish?.Invoke();
    }
    
    public void IceSlideEnlargeFinish()
    {
        onIceSlideEnlargeFinish?.Invoke();
    }


    
}
