using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnTrigger: MonoBehaviour
{
    public Transform placeToSpawn;
    public Vector3 offset;
    public GameObject objectToSpawn;
    public float delay = 0f;
    
    public void Trigger()
    {
        StartCoroutine(TriggerCoroutine());
    }

    private IEnumerator TriggerCoroutine()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(objectToSpawn, placeToSpawn.position+offset, Quaternion.identity);

    }
}