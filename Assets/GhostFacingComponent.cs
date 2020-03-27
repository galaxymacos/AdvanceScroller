using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFacingComponent : MonoBehaviour
{
    public Action facingDelegate;

    public bool IsFacingRight => transform.localScale.x > 0;
    public event Action<ChangeFacingTo> onFacingChanged;

    private Rigidbody2D rb;
    private GhostStats ghostStats;
    public FacingCondition defaultFacingState;

    public enum ChangeFacingTo
    {
        ChangeToLeft, 
        ChangeToRight
    }

    public enum FacingCondition
    {
        FaceByRelativePosition,
        FaceByVelocity
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ghostStats = GetComponent<GhostStats>();
        SetFacingDelegate(defaultFacingState);
        onFacingChanged += CheckFacing;
    }

    public void SetFacingDelegate(FacingCondition condition)
    {
        switch (condition)
        {
            case FacingCondition.FaceByVelocity:
                facingDelegate = FacingByVelocity;
                break;
            case FacingCondition.FaceByRelativePosition:
                facingDelegate = FacingByRelativePosition;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(condition), condition, null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        facingDelegate?.Invoke();
    }
    
    

    private float velocityXLastFrame;
    private void FacingByVelocity()
    {
        if (rb.velocity.x > 0 && velocityXLastFrame <= 0)
        {
            onFacingChanged(ChangeFacingTo.ChangeToRight);

        }
        if (rb.velocity.x < 0 && velocityXLastFrame >= 0)
        {
            onFacingChanged(ChangeFacingTo.ChangeToLeft);
        }
        velocityXLastFrame = rb.velocity.x;


    }

    private bool PlayerAtRightLastFrame;
    private void FacingByRelativePosition()
    {
        if (PlayerAtRightLastFrame && ghostStats.playerToChase.transform.position.x - transform.position.x < 0)
        {
            onFacingChanged(ChangeFacingTo.ChangeToLeft);
        }
        if (!PlayerAtRightLastFrame && ghostStats.playerToChase.transform.position.x - transform.position.x > 0)
        {
            onFacingChanged(ChangeFacingTo.ChangeToRight);
        }
        PlayerAtRightLastFrame = ghostStats.playerToChase.transform.position.x - transform.position.x > 0;
    }

    private void CheckFacing(ChangeFacingTo changeFacingTo)
    {
        switch (changeFacingTo)
        {
            case ChangeFacingTo.ChangeToLeft:
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                break;
            case ChangeFacingTo.ChangeToRight:
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                break;
        }
    }
    
    

}
