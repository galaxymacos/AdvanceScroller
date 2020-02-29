using System.Collections;
using System.Linq;
using UnityEngine;

public class UniqueSkillPauseComponent : MonoBehaviour
{
    private PlayerCharacter owner;
    [SerializeField] private float showOffTime = 1f;
    public void Use()
    {
        owner = GetOwner();
        owner.GetComponent<IPauseable>().UnPause();
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

    public void UniqueSkillEnd()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.UnPause();
        }

    }

    public void ShowOff()
    {
        StartCoroutine(ShowOffCoroutine());
    }

    private IEnumerator ShowOffCoroutine()
    {
        var pauseables = FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();
        foreach (IPauseable pauseable in pauseables)
        {
            pauseable.Pause();
        }

        yield return new WaitForSeconds(showOffTime);
        Use();
    }

}