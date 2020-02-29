using System;
using System.Collections;
using System.Linq;
using UnityEngine;

/// <summary>
/// Control the behavior when the player uses unique skill
/// </summary>
public class UniqueSkillComponent : MonoBehaviour
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
        LightingManager.instance.TurnOnAllLights();
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
        LightingManager.instance.TurnOffAllLights();
        if (uniqueSkillFireParticlePrefab)
        {
            Instantiate(uniqueSkillFireParticlePrefab, owner.transform.position, Quaternion.identity);
        }
    }
}