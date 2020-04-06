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

    private GameObject ultraSpace;

    private void Awake()
    {
        collisionCollector.onCollisionDetect += PlaceOn;
    }

    public void Setup(PlayerCharacter _owner)
    {
        owner = _owner;
    }

    public void PlaceOn(Collider2D target)
    {
        print("place on");
        if (collisionCollector.detectedColliders.Count >= 2 && ultraSpace == null)
        {
            print("instantiate");
            ultraSpace = Instantiate(ultraSpacePrefab, target.transform.position, Quaternion.identity);
        }
    }

    public class UltraSpaceData
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

    private void Update()
    {
        if (ultraSpace != null)
        {
            LimitUltraSpaceToBound();
        }
    }

    private void LimitUltraSpaceToBound()
    {
        var ultraSpaceData = GetUltraSpaceBound();
        if (ultraSpaceData != null)
        {
            ultraSpace.transform.position = ultraSpaceData.center;
            ultraSpace.transform.localScale = new Vector3(ultraSpaceData.width, ultraSpaceData.height, 1);
        }
    }
    
    public UltraSpaceData GetUltraSpaceBound()
    {
        var list = collisionCollector.detectedColliders.Select(col => col.transform).ToList();
        // list.Add(owner.transform);
        if (list.Count >= 2)
        {
            
            float top = Mathf.Max(list.Select(trans => trans.position.y).ToArray());
            float left = Mathf.Min(list.Select(trans => trans.position.x).ToArray());
            float right = Mathf.Max(list.Select(trans => trans.position.x).ToArray());
            float bottom = Mathf.Min(list.Select(trans => trans.position.y).ToArray());
            Vector3 center = new Vector3((right + left)/2, (top + bottom)/2);
            print(center);
            float width = right - left + extraWidth;
            float height = top - bottom + extraHeight;
            return new UltraSpaceData(center, width, height);
        }

        return null;
    }
    
}
