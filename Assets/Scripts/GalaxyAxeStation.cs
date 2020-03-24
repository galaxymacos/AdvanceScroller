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
    private float armLength = 2f;
    
    

    public void Setup(Transform _owner)
    {
        owner = _owner;
        gameObject.layer = _owner.gameObject.layer;
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
    //
    

    private IEnumerator SetupCoroutine()
    {
        for (int i = 0; i < axeSprites.Count; i++)
        {
            var galaxyAxe = Instantiate(galaxyAxePrefab, transform.position, Quaternion.identity);
            galaxyAxe.layer = owner.gameObject.layer;
            galaxyAxe.GetComponent<NewProjectileDamageComponent>().Setup(GetComponent<PlayerCharacter>());
            galaxyAxe.GetComponent<SpriteRenderer>().sprite = axeSprites[i];
            Vector3 movementVector = Quaternion.AngleAxis(-45*i, Vector3.forward) * Vector2.up * armLength;
            Vector3 targetVector = movementVector + transform.position;
            galaxyAxe.transform.DOMove(targetVector, 0.1f);
            galaxyAxe.transform.parent = transform;
            yield return new WaitForSeconds(0.15f);
        }

        yield return new WaitForSeconds(0.9f);
        rotating = true;
        transform.parent = null;
        BindToOwner();
    }

    private void BindToOwner()
    {
        GetComponent<SpringJoint2D>().connectedBody = owner.Find("GalaxyAxeStationBinder").GetComponent<Rigidbody2D>();
        
        var spriteJoint = GetComponent<SpringJoint2D>();
        spriteJoint.autoConfigureDistance = false;
        spriteJoint.distance = 0.05f;
    }
}