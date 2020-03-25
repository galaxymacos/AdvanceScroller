using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collision2D))]
public class PlatformStickComponent : MonoBehaviour
{
    private List<GameObject> stickTransforms;

    private bool canAttach = true;

    private void Awake()
    {
        stickTransforms = new List<GameObject>();
        IceSlideEventSystem.onIceSlideFinish += ClearAttachingGameObject;
    }

    private void OnDestroy()
    {
        IceSlideEventSystem.onIceSlideFinish -= ClearAttachingGameObject;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!canAttach) return;
        var playerCharacter = other.gameObject.GetComponent<PlayerCharacter>();
        if (playerCharacter != null)
        {
            playerCharacter.isGroundedOverride = true;
            playerCharacter.overrideGrounded = true;
            stickTransforms.Add(other.gameObject);
            other.transform.parent = transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        var playerCharacter = other.gameObject.GetComponent<PlayerCharacter>();

        if (playerCharacter != null)
        {
            playerCharacter.isGroundedOverride = false;
            stickTransforms.Remove(other.gameObject);
            other.transform.parent = null;
        }
    }

    private void ClearAttachingGameObject()
    {
        canAttach = false;
        foreach (GameObject stickTransform in stickTransforms)
        {
            stickTransform.transform.parent = null;
        }
    }
}