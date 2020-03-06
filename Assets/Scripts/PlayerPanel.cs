using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{ 
    public PlayerCharacter player;

    public ProgressBar hpBar; 
    public ProgressBar energyBar;
    public Image ultimateBar;
    CharacterHealthComponent characterHealthComponent;
    CharacterEnergyComponent characterEnergyComponent;
    CharacterUltimateComponent characterUltimateComponent;

    public bool setupFinished;
    public Action onPlayerSetup;

    
    // Start is called before the first frame update
    private void Awake()
    {
        onPlayerSetup += SetUp;
    }

    private void SetUp()
    {
        characterHealthComponent = player.GetComponent<CharacterHealthComponent>();
        characterEnergyComponent = player.GetComponent<CharacterEnergyComponent>();
        characterUltimateComponent = player.GetComponent<CharacterUltimateComponent>();
        setupFinished = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!setupFinished) return;
        
        hpBar.currentPercent = (float)characterHealthComponent.currentHealth/characterHealthComponent.maxHealth*100;
        energyBar.currentPercent = characterEnergyComponent.currentEnergy / characterEnergyComponent.maxEnergy*100;
        ultimateBar.fillAmount = characterUltimateComponent.GetRagePercentage;
    }
}