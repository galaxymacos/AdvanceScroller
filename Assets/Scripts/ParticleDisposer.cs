using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ParticleDisposer : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).loop)
        {
            print("destroy in "+GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay+" seconds ");
            Destroy(transform.root.gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }
}
