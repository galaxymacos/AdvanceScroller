using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstantKill : MonoBehaviour, IUniqueSkill
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.Pause();
        }
        // BulletTimeManager.instance.Register(2f);
    }

    public void UniqueSkillEnd()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.UnPause();
        }

    }
}