using UnityEngine;

public class ProjectileFlipComponent
{
    private readonly Transform transform;
    private bool moveRight;
    public ProjectileFlipComponent(Transform transform, bool moveRight)
    {
        this.transform = transform;
        this.moveRight = moveRight;
    }
    public void Flip()
    {
        var localScale = transform.localScale;

        if (moveRight)
        {
            localScale.x = 1;
        }
        else
        {
            localScale.x = -1;
        }
        transform.localScale = localScale;

    }
}