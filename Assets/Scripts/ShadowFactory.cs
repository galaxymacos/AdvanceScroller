using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFactory : MonoBehaviour
{
    [SerializeField] private GameObject forceCancelShadow;
    [SerializeField] private GameObject dissolveShadow;
    

    public static ShadowFactory instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CreateForceCancelShadow(PlayerCharacter playerCharacter)
    {
        GameObject shadow = Instantiate(forceCancelShadow, playerCharacter.transform.position, playerCharacter.transform.rotation);
        // shadow.transform.localScale = playerCharacter.transform.localScale;
        shadow.GetComponent<ForceCancelShadowCreationMessager>().Setup(playerCharacter.GetComponent<SpriteRenderer>());
        
        
        // shadow.GetComponent<SpriteRenderer>().sprite = playerCharacter.GetComponent<SpriteRenderer>().sprite;
        // shadow.GetComponent<ForceCancelShadow>().sr = shadow.GetComponent<SpriteRenderer>();
    }

    public void CreatedissolveShadow(PlayerCharacter playerCharacter)
    {
        GameObject shadow = Instantiate(dissolveShadow, playerCharacter.transform.position, playerCharacter.transform.rotation);
        shadow.GetComponent<DissolveShadowCreationMessager>().Setup(playerCharacter.GetComponent<SpriteRenderer>());

    }
}
