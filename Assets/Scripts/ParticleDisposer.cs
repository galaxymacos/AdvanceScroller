using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisposer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }
}
