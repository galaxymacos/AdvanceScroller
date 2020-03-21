using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GalaxyAxeStation : MonoBehaviour
{
    public List<Sprite> axeSprites;
    public GameObject galaxyAxePrefab;
    public float rotateSpeed = 50;
    private bool rotating;
    private Transform owner;
    
    

    public void Setup(Transform _owner)
    {
        owner = _owner;
        StartCoroutine(SetupCoroutine());
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, owner.position, 0.1f);

        if (rotating)
        {
            transform.Rotate(-Vector3.forward, rotateSpeed*Time.deltaTime);
        }
    }

    private IEnumerator SetupCoroutine()
    {
        for (int i = 0; i < axeSprites.Count; i++)
        {
            var galaxyAxe = Instantiate(galaxyAxePrefab, transform.position, Quaternion.identity);
            galaxyAxe.GetComponent<SpriteRenderer>().sprite = axeSprites[i];
            Vector3 movementVector = Quaternion.AngleAxis(-45*i, Vector3.forward) * Vector2.up;
            Vector3 targetVector = movementVector + transform.position;
            galaxyAxe.transform.DOMove(targetVector, 1);
            galaxyAxe.transform.parent = transform;
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(0.7f);
        rotating = true;
    }

    
    
}
