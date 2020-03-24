using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationDisposer : MonoBehaviour
{
    public float delay;

    public event Action onSpriteDestroy;
    // Start is called before the first frame update
    void Start()
    {
            Destroy(transform.root.gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    private void OnDestroy()
    {
        onSpriteDestroy?.Invoke();
    }
}