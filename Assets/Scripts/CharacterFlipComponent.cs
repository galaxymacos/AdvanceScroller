using UnityEngine;

public class CharacterFlipComponent
{
    private Transform transform;
    private Rigidbody2D rb;
    public CharacterFlipComponent(Transform transform)
    {
        this.transform = transform;
        rb = transform.GetComponent<Rigidbody2D>();
    }
    
    public void Flip(float horizontalMovement)
    {
        Vector3 localScale = transform.localScale;

        if (rb.velocity.x < 0 && horizontalMovement < 0)
        {
            localScale.x = -1;
            transform.localScale = localScale;
        }
        else if (rb.velocity.x > 0 && horizontalMovement > 0)
        {
            localScale.x = 1;
            transform.localScale = localScale;

        }
    }
}