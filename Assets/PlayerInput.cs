using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputActions inputAction;

    public bool jump;

    public float horizontalMovement;
    // Start is called before the first frame update
    void Awake()
    {
        inputAction = new InputActions();
        inputAction.Player.Jump.performed += ctx => jump = true;
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
