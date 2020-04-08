using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
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
        // if (collisionCollector.detectedColliders.Count >= 2)
        // {
            if (ultraSpace == null)
            {
                ultraSpace = Instantiate(ultraSpacePrefab, target.transform.position, Quaternion.identity);
                ultraSpace.GetComponent<UltraSpace>().Setup(owner);
                ultraSpace.GetComponent<Timer>().onTimerEndEvent += SpaceClosing;
            }

            LimitUltraSpaceToBound();
        // }
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

    private List<Tweener> spaceTweeners;
    private void LimitUltraSpaceToBound()
    {
        var ultraSpaceBound = GetUltraSpaceBound();
        if (spaceTweeners == null || spaceTweeners.Count == 0)
        {
            Release();
            spaceTweeners = new List<Tweener>();
            Tweener tweener1 = null;
            tweener1 = DOTween.To(() => ultraSpace.transform.position, result => ultraSpace.transform.position=result, ultraSpaceBound.center,
                1).OnComplete(() =>
            {
                spaceTweeners.Remove(tweener1);
            });
            Tweener tweener2 = null;
            tweener2 = DOTween.To(() => ultraSpace.transform.localScale, result => ultraSpace.transform.localScale = result,
                new Vector3(ultraSpaceBound.width, ultraSpaceBound.height, 1), 1).OnComplete(()=>
            {
                Lockdown();
                spaceTweeners.Remove(tweener2);
            });
            spaceTweeners.Add(tweener1);
            spaceTweeners.Add(tweener2);
        }
        else
        {
            Release();
            spaceTweeners[0].ChangeValues(ultraSpace.transform.position, ultraSpaceBound.center);
            spaceTweeners[1].ChangeValues(ultraSpace.transform.localScale,
                new Vector3(ultraSpaceBound.width, ultraSpaceBound.height, 1));
        }
        
        
    }

    private void SpaceClosing()
    {
        ultraSpace.GetComponent<Timer>().onTimerEndEvent -= SpaceClosing;
        Release();
        DOTween.To(() => ultraSpace.transform.localScale, result => ultraSpace.transform.localScale = result,
            Vector3.zero, 2).OnComplete(()=>Destroy(gameObject));
    }
    
    

    private void Lockdown()
    {
        foreach (Collider2D childCollider in ultraSpace.GetComponentsInChildren<Collider2D>())
        {
            childCollider.enabled = true;
        }
    }

    private void Release()
    {
        foreach (Collider2D childCollider in ultraSpace.GetComponentsInChildren<Collider2D>())
        {
            childCollider.enabled = false;
        }
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