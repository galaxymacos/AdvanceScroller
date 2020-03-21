using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAxe : MonoBehaviour
{

    public GameObject galaxyAxePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnUltimateAxe()
    {
        GameObject galaxyAxe = Instantiate(galaxyAxePrefab, transform.position, Quaternion.identity);
        // galaxyAxe.GetComponent<GalaxyAxe>().Setup();
    }
}
