using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : MonoBehaviour
{
    [SerializeField] private DamageData DamageData;



    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver != null)
        {
            damageReceiver.Analyze(DamageData, transform);

        }
    }
}
