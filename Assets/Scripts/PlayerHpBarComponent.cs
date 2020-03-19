using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBarComponent : MonoBehaviour
{
    private PlayerCharacter owner;

    private PlayerPanel playerPanel;
    private Slider slider;

    private CharacterHealthComponent chc;
    

    void Awake()
    {
        playerPanel = GetComponentInParent<PlayerPanel>();
        playerPanel.onPlayerSetupFinish += SetUp;
        slider = GetComponent<Slider>();
    }

    private void SetUp()
    {
        owner = playerPanel.player;
        chc = owner.GetComponent<CharacterHealthComponent>();
        slider.maxValue = chc.maxHealth;
        slider.value = chc.currentHealth;
        chc.onTakeHit += UpdateUI;
        chc.onHealthChanged += UpdateUI;
    }

    private void UpdateUI(CharacterHealthComponent characterHealthComponent)
    {
        slider.value = chc.currentHealth;
    }
}
