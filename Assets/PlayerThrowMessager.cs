using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacter))]
public class PlayerThrowMessager : MonoBehaviour
{
    private PlayerCharacter playerToThrow;

    public PlayerCharacter PlayerToThrow => playerToThrow;

    private PlayerCharacter owner;

    public PlayerCharacter Owner => owner;

    [SerializeField] private CatchComponent catchComponent;

    private void Awake()
    {
        owner = GetComponent<PlayerCharacter>();
        owner.onCatchingSuccess += GetReferenceToPlayerToThrow;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetReferenceToPlayerToThrow()
    {
        playerToThrow = catchComponent.PlayerCaught;
    }
}
