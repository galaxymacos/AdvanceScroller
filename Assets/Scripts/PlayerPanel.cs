using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{ 
    public PlayerCharacter player;
    public Image ultimateBar;
    CharacterUltimateComponent characterUltimateComponent;

    public bool setupFinished;
    public Action onPlayerSetup;
    public Action onPlayerSetupFinish;

    
    // Start is called before the first frame update
    private void Awake()
    {
        onPlayerSetup += SetUp;
    }

    private void SetUp()
    {
        characterUltimateComponent = player.GetComponent<CharacterUltimateComponent>();
        setupFinished = true;
        onPlayerSetupFinish?.Invoke();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!setupFinished) return;
        
        ultimateBar.fillAmount = characterUltimateComponent.GetRagePercentage;
    }
}