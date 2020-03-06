using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class should be placed under the gameobject of every map
/// </summary>
public class MapPlayerSpawnData : MonoBehaviour
{
    [SerializeField] private List<Transform> _playerSpawnPositions;

    public List<Transform> PlayerSpawnPositions => _playerSpawnPositions;
}
