using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFalling : MonoBehaviour
{
    [SerializeField] public float speed;
   
    void Update()
    {
        transform.Translate(new Vector2(0f, 1f) * Time.deltaTime * speed);
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }


}
