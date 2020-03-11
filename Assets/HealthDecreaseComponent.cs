using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDecreaseComponent : MonoBehaviour
{
    private PlayerCharacter owner;

    private PlayerPanel playerPanel;
    private Slider slider;

    private CharacterHealthComponent chc;

    [SerializeField] private float decreaseSpeed = 0.05f;

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
        chc.OnTakeHit += UpdateUI;
        chc.onLoseHealth += UpdateUI;
    }

    private void UpdateUI(CharacterHealthComponent characterHealthComponent)
    {
        if (chc.currentHealth > slider.value)
        {
            slider.value = chc.currentHealth;
            StopCoroutine(Drain());
        }
        else
        {
            StopCoroutine(Drain());
            StartCoroutine(Drain());
        }
    }

    private IEnumerator Drain()
    {
        while (slider.value - chc.currentHealth > Mathf.Epsilon)
        {
            slider.value -= slider.maxValue * decreaseSpeed * Time.deltaTime;
            yield return null;
        }
    }
}