﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public Vector3 velocity;
    public float smoothTime = 0.24f;

    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float zoomLimiter = 10f;
    // public Camera camera;
    [SerializeField] private Camera myCamera;

    private bool hasSetup;

    private void Awake()
    {
        targets = new List<Transform>();
        PlayerCharacterSpawner.onPlayerSpawnFinished += Setup;
        CharacterHealthComponent.onPlayerDie += DeletePlayer;
    }

    private void FixedUpdate()
    {
        if (!hasSetup || targets.Count == 0)
        {
            return;
        }
        Move();
        Zoom();
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance()/zoomLimiter);
        myCamera.orthographicSize = Mathf.Lerp(myCamera.orthographicSize, newZoom, Time.deltaTime);
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 1; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        
        return Mathf.Max(bounds.size.x, bounds.size.y)  ;
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    public void Setup()
    {
        List<PlayerCharacter> players = PlayerCharacterSpawner.instance.charactersForPlayer;
        foreach (PlayerCharacter player in players)
        {
            targets.Add(player.transform);
        }

        hasSetup = true;
    }

    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    private void DeletePlayer(CharacterHealthComponent characterHealthComponent)
    {
        var playerCharacter = characterHealthComponent.transform;
        print("not tracking player because "+playerCharacter.gameObject.name+" is dead");

        targets.Remove(playerCharacter);
    }
}
