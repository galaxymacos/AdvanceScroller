using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputDistributor : MonoBehaviour
{
    private static int _currentPlayerInputNum = 0;

    public static PlayerInputDistributor instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            print("Can't have more than one "+name);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DistributeInput(NewPlayerInput input)
    {
        print("distribute the generated player input object to the player "+_currentPlayerInputNum);
        _currentPlayerInputNum++;

    }
}
