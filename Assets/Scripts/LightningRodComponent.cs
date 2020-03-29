using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRodComponent : MonoBehaviour
{
    public GameObject lightning;

    [SerializeField] private float delay = 2f;
    [SerializeField] private float delayCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delayCounter > 0)
        {
            delayCounter -= Time.deltaTime;
            if (delayCounter <= 0)
            {
                Instantiate(lightning, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }

    public void CountdownStart()
    {
        delayCounter=delay;
    }
}
