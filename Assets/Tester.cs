using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Jump", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        rb.velocity = (new Vector3(10,10));

    }
}
