using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;

    private void Start()
    {
        StartOperation();
    }

    private void StartOperation()
    {
        MoveToEndPosition();
    }

    private void MoveToEndPosition()
    {
        transform.DOMove(endPosition.position, 2).OnComplete(MoveToStartPosition);

        print("move to end position");
    }

    private void MoveToStartPosition()
    {
        transform.DOMove(startPosition.position, 2).OnComplete(MoveToEndPosition);
        print("move to end position");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerCharacter>() != null)
        {
            other.transform.parent = transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerCharacter>() != null)
        {
            other.transform.parent = null;
        }
    }
}