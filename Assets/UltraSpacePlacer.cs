using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UltraSpacePlacer : MonoBehaviour
{
    public GameObject ultraSpacePrefab;
    private PlayerCharacter owner;
    [SerializeField] private CollisionCollecter collisionCollector;
    [SerializeField] private float extraHeight = 5f;
    [SerializeField] private float extraWidth = 10f;

    [SerializeField] private bool onlyDetectOnce = true;
    private bool hasSpawned;

    private GameObject ultraSpace;

    private void Awake()
    {
        collisionCollector.onCollisionDetect += PlaceOn;
    }

    private void OnDestroy()
    {
        collisionCollector.onCollisionDetect -= PlaceOn;
    }

    public void Setup(PlayerCharacter _owner)
    {
        owner = _owner;
    }

    private void PlaceOn(Collider2D target)
    {
        if (collisionCollector.detectedColliders.Count >= 2)
        {
            if (ultraSpace == null)
            {
                ultraSpace = Instantiate(ultraSpacePrefab, target.transform.position, Quaternion.identity);
                ultraSpace.GetComponent<UltraSpace>().Setup(owner);
            }

            LimitUltraSpaceToBound();
        }
    }

    private class UltraSpaceData
    {
        public UltraSpaceData(Vector3 center, float width, float height)
        {
            this.center = center;
            this.width = width;
            this.height = height;
        }

        public Vector3 center;
        public float width;
        public float height;
    }

    private void LimitUltraSpaceToBound()
    {
        var ultraSpaceBound = GetUltraSpaceBound();
        ultraSpace.transform.position = ultraSpaceBound.center;
        ultraSpace.transform.localScale = new Vector3(ultraSpaceBound.width, ultraSpaceBound.height, 1);
    }

    private UltraSpaceData GetUltraSpaceBound()
    {
        var list = collisionCollector.detectedColliders.Select(col => col.transform).ToList();

        float top = Mathf.Max(list.Select(trans => trans.position.y).ToArray());
        float left = Mathf.Min(list.Select(trans => trans.position.x).ToArray());
        float right = Mathf.Max(list.Select(trans => trans.position.x).ToArray());
        float bottom = Mathf.Min(list.Select(trans => trans.position.y).ToArray());
        Vector3 center = new Vector3((right + left) / 2, (top + bottom) / 2);
        float width = right - left + extraWidth;
        float height = top - bottom + extraHeight;
        return new UltraSpaceData(center, width, height);
    }
}