using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenThrornsTrap : MonoBehaviour
{
    public DamageData damageData;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver != null)
        {
            damageReceiver.Analyze(damageData, transform);
            
        }
    }
   
    

}
