using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelTeleport : MonoBehaviour
{

    [SerializeField] private Transform[] IceChannel;
    
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        var teleportTarget = col.GetComponent<PlayerCharacter>();
        int Rn = Random.Range(0, IceChannel.Length);
        print("teleport");
        if (teleportTarget != null)
        {
            
            col.transform.position = IceChannel[Rn].transform.position;
        }
    }
}
