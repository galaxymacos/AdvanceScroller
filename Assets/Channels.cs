using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Channels : MonoBehaviour
{
    public ChannelTeleport IceChannel;
    //public Transform positionBeforeTeleport;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var teleportTarget = col.GetComponent<PlayerCharacter>();
        int Rn = Random.Range(0, IceChannel.teleport.Length);

        if (teleportTarget != null)
        {

            col.transform.position = IceChannel.teleport[Rn].transform.position;
        }
    }
}
