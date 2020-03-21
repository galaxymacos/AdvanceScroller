using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateAxe : MonoBehaviour
{

    public GameObject galaxyAxeStationPrefab;
   

    public void SpawnUltimateAxe()
    {
        GameObject galaxyAxeStation = Instantiate(galaxyAxeStationPrefab, transform);
        galaxyAxeStation.GetComponent<GalaxyAxeStation>().Setup(transform);
    }
}
