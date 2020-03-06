using System;
using System.Collections;
using System.Linq;
using UnityEngine;

/// <summary>
/// Control the behavior when the player uses unique skill
/// </summary>
public class UltimateEffectComponent : MonoBehaviour
{
    private PlayerCharacter owner;
    [SerializeField] private float showOffTime = 1f;
    [SerializeField] private GameObject uniqueSkillFireParticlePrefab;

    public Action onStartShowOff;

    private void Awake()
    {
        onStartShowOff += PauseAll;
        onStartShowOff += HandleLighting;
        owner = GetOwner();

    }

    public void ShowOff()
    {
        onStartShowOff?.Invoke();
        StartCoroutine(ShowOffCoroutine());
    }
    
    public void End()
    {
        print("turn on all lighting");
        // LightingManager.instance.TurnOnAllLights(); TODO add it back if new lighting state machine not working
        LightingManager.instance.lightOnTrigger = true;
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.UnPause();
        }

    }
    
    private void Use()
    {
        owner.GetComponent<IPauseable>().UnPause();
    }

    private IEnumerator ShowOffCoroutine()
    {
        yield return new WaitForSeconds(showOffTime);
        Use();
    }

    private void PauseAll()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.Pause();
        }
    }

    private PlayerCharacter GetOwner()
    {
        var ownerTransfomr = transform.root;
        owner = ownerTransfomr.GetComponent<PlayerCharacter>();
        if (owner != null)
        {
            print("successfully fetch the owner");
        }

        return owner;
    }

    public void HandleLighting()
    {
        // LightingManager.instance.TurnOffAllLights(); // TODO add it back if lighting state machine doesn't work
        LightingManager.instance.lightOffTrigger = true;
        if (uniqueSkillFireParticlePrefab)
        {
            Instantiate(uniqueSkillFireParticlePrefab, owner.transform.position, Quaternion.identity);
        }
    }
}