using System;
using UnityEngine;

public class ParticleDisposer : MonoBehaviour
{
    public float delay;

    public event Action onParticleDistroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.root.gameObject, delay);        
    }

    private void OnDestroy()
    {
        print("destroy lightning");
        onParticleDistroy?.Invoke();
    }
}