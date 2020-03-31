using System;
using UnityEngine;

public class GhostCapeBuff : MonoBehaviour, IPlayerBuff
{
    [SerializeField] private float duration = 10;
    private float durationCounter;

    [SerializeField] private float invincibleDuration = 0.7f;
    private float invincibleDurationCounter;
    [SerializeField] private float invincibleInterval = 1.6f;
    private float invincibleIntervalCounter;
    private PlayerCharacter playerToBuff;

    public event Action onGhostingStart;
    public event Action onGhostingEnd;

    private Material playerMat;

    private bool hasSetup;

    public void Setup(PlayerCharacter player)
    {
        durationCounter = duration;
        playerToBuff = player;
        playerMat = player.GetComponent<SpriteRenderer>().material;
        playerToBuff.onFacingDirectionChanged += ActivateGhosting;
        playerToBuff.GetComponent<CharacterDamageReceiver>().invincibleConditions.Add(isGhosting);
        hasSetup = true;
        onGhostingEnd += SetOpaque;
    }

    private void OnDestroy()
    {
        playerToBuff.onFacingDirectionChanged -= ActivateGhosting;
        playerToBuff.GetComponent<CharacterDamageReceiver>().invincibleConditions.Remove(isGhosting);
        if (hasSetup)
        {
            onGhostingEnd -= SetOpaque;
        }
    }

    private void ActivateGhosting()
    {
        if (!canGhost) return;
        invincibleIntervalCounter = invincibleInterval;
        invincibleDurationCounter = invincibleDuration;
        onGhostingStart?.Invoke();
    }


    private bool isGhosting() => invincibleDurationCounter > 0;
    private bool canGhost => invincibleIntervalCounter <= 0;

    private void Update()
    {
        if (invincibleIntervalCounter > 0)
        {
            invincibleIntervalCounter -= Time.deltaTime;
            if (invincibleIntervalCounter <= 0)
            {
                // player can ghost again
            }
        }

        if (durationCounter > 0)
        {
            durationCounter -= Time.deltaTime;
            if (durationCounter <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (invincibleDurationCounter > 0)
        {
            invincibleDurationCounter -= Time.deltaTime;
            if (invincibleDurationCounter <= 0)
            {
                onGhostingEnd?.Invoke();
            }
        }

        if (isGhosting())
        {
            SetTransparent();
        }
        else
        {
            SetOpaque();

        }
    }

    private void SetTransparent()
    {
        playerMat.SetFloat("_Alpha", 0.5f);
    }

    private void SetOpaque()
    {
        playerMat.SetFloat("_Alpha", 1f);
    }
}