using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] private PlayerCharacter playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        if (!playerCharacter.isFacingRight)
        {
            print("player should be initialized to face right");
        }
        playerCharacter.onFacingDirectionChanged += Flip;

    }
    public void Flip()
    {
        var localPosition = transform.localPosition;
        localPosition = new Vector3(-localPosition.x, localPosition.y, localPosition.z);
        transform.localPosition = localPosition;
    }
}
