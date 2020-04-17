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
    private bool enlarging;
    private Transform owner;
    private float armLength = 2f;
    private List<GameObject> galaxyAxes;
    [SerializeField] private float existDuration = 10f;
    private float existDurationCounter;

    private void Awake()
    {
        galaxyAxes = new List<GameObject>();
    }

    public void Setup(Transform _owner)
    {
        owner = _owner;
        gameObject.layer = _owner.gameObject.layer;
        StartCoroutine(SetupCoroutine());
    }

    private void Update()
    {
        if (rotating)
        {
            if (owner != null)
            {
                transform.position = Vector3.Lerp(transform.position, owner.position, 0.1f);
            }

            transform.Rotate(-Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        if (existDurationCounter > 0)
        {
            existDurationCounter -= Time.deltaTime;
            if (existDurationCounter <= 0)
            {
                owner = null;
                enlarging = true;
                StopAllCoroutines();
                GetComponent<SpringJoint2D>().enabled = false;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().simulated = false;
            }
        }

        if (enlarging)
        {
            // if (rotateSpeed < 200)
            // {
                // rotateSpeed += Time.deltaTime * 15f;
            // }
            foreach (GameObject galaxyAx in galaxyAxes)
            {
                // galaxyAx.transform.rotation = Quaternion.Euler(0,0,0);
                Vector2 direction = (galaxyAx.transform.position - transform.position).normalized;
                galaxyAx.transform.Translate(transform.InverseTransformVector(direction) * (2*Time.deltaTime));
            }
        }
    }
    //


    private IEnumerator SetupCoroutine()
    {
        for (int i = 0; i < axeSprites.Count; i++)
        {
            var galaxyAxe = Instantiate(galaxyAxePrefab, transform.position, Quaternion.identity);
            galaxyAxes.Add(galaxyAxe);
            galaxyAxe.layer = owner.gameObject.layer;
            galaxyAxe.GetComponent<NewProjectileDamageComponent>().Setup(transform.root.gameObject);
            galaxyAxe.GetComponent<SpriteRenderer>().sprite = axeSprites[i];
            Vector3 movementVector = Quaternion.AngleAxis(-45 * i, Vector3.forward) * Vector2.up * armLength;
            Vector3 targetVector = movementVector + transform.position;
            galaxyAxe.transform.DOMove(targetVector, 0.1f);
            galaxyAxe.transform.parent = transform;
            yield return new WaitForSeconds(0.15f);
        }

        yield return new WaitForSeconds(0.9f);
        rotating = true;
        existDurationCounter = existDuration;
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