using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMessager : MonoBehaviour
{
    private IEnumerator LayerRecover()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerCharacter[]  players = FindObjectsOfType<PlayerCharacter>();
        foreach (var player in players)
        {
            if (player != GetComponent<PlayerCharacter>())
            {
                player.whatIsGround |= 1 << transform.gameObject.layer;
            }
        }
    }

    private void DisableGroundLayer()
    {
        PlayerCharacter[]  players = FindObjectsOfType<PlayerCharacter>();
        foreach (var player in players)
        {
            if (player != GetComponent<PlayerCharacter>())
            {
                print("set ground layer of the champion "+player.gameObject.name);
                player.whatIsGround &= ~(1 << transform.gameObject.layer);
            }
        }
    }

    public void TemporaryDisableLayer()
    {
        print("Temporary disable Layer");
        DisableGroundLayer();
        StartCoroutine(LayerRecover());
    }
}
