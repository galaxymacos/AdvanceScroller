using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPauser : MonoBehaviour , IPauseable
{
    [SerializeField] IceSpike gameobject;
    private float speedBeforePause;
    public void Pause()
    {
        gameobject.speed = 0;
    }

    public void UnPause()
    {
        gameobject.speed = speedBeforePause;
    }

    // Start is called before the first frame update
    void Start()
    {
        speedBeforePause = gameobject.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
