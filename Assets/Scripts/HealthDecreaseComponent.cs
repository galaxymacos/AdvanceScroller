using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Sprites
{
    public class HealthDecreaseComponent : MonoBehaviour
    {
        private PlayerCharacter owner;

        private PlayerPanel playerPanel;
        private Slider slider;

        private CharacterHealthComponent chc;
        private bool hasSetUp;
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
            chc.onTakeHit += UpdateUI;
            chc.onLoseHealth += UpdateUI;
            hasSetUp = true;
        }

        private void OnDestroy()
        {
            if (hasSetUp)
            {
                chc.onTakeHit -= UpdateUI;
                chc.onLoseHealth -= UpdateUI;
            }
            
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
                if (gameObject.activeSelf)
                {
                    StartCoroutine(Drain());
                    
                }
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
}