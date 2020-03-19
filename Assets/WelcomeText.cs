using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MenuStateMachine.onStateChangedToMap += Disable;
        
    }

    private void Disable()
    
    {
        MenuStateMachine.onStateChangedToMap -= Disable;

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
