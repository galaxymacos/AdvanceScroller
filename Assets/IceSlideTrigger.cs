using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlideTrigger : MonoBehaviour
{
    private bool hasStarted;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hasStarted) return;

        if (other.gameObject.GetComponent<PlayerCharacter>())
        {
            hasStarted = true;
            IceSlideEventSystem.instance.IceSlideStart();
        }
    }
}
