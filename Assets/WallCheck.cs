using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] private PlayerCharacter playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter.onFacingDirectionChanged += Flip;

    }
    public void Flip()
    {
        transform.localPosition = new Vector3(-transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }
}
