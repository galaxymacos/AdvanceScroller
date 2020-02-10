using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFacingComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void Setup(PlayerCharacter owner)
    {
        if (!owner.isFacingRight)
        {
            transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
