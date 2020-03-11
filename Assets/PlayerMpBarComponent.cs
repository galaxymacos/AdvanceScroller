using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMpBarComponent : MonoBehaviour
{
    private PlayerCharacter owner;

    private PlayerPanel playerPanel;
    private Slider slider;

    private CharacterEnergyComponent chc; 
    private bool hasSetUp;

    void Awake()
    {
        playerPanel = GetComponentInParent<PlayerPanel>();
        playerPanel.onPlayerSetupFinish += SetUp;
        slider = GetComponent<Slider>();
    }

    public void SetUp()
    {
        owner = playerPanel.player;
        chc = owner.GetComponent<CharacterEnergyComponent>();
        slider.maxValue = chc.maxEnergy;
        hasSetUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSetUp) return;

        slider.value = chc.currentEnergy;
    }
}
