using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateIconComponent : MonoBehaviour
{
    private PlayerPanel playerPanel;

    private void Awake()
    {
        playerPanel = GetComponentInParent<PlayerPanel>();
        playerPanel.onPlayerSetupFinish += GainSprite;
    }


    private void GainSprite()
    {
        if (playerPanel.player.GetComponent<UltimateComponent>() == null)
        {
            Debug.LogError(playerPanel.player.name +" does not have ultimate component");
            return;
        }
        GetComponent<Image>().sprite = playerPanel.player.GetComponent<UltimateComponent>().ultimateIcon;
    }

}
