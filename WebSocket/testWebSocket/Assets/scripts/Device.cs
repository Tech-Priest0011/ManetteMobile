using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Device : MonoBehaviour
{
    [SerializeField]
    private WsClient wsClient;

    private CharController charController;


    void Awake()
    {
        charController = new CharController();

        charController.Player.Move.performed  += ExecuteMove;
    }

    private void ExecuteMove(InputAction.CallbackContext context)
    {
        //Debug.Log("X: " + context.ReadValue<Vector2>().x);
        //Debug.Log("Y`" + context.ReadValue<Vector2>().y);

        wsClient.EnvoieMesage(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
    }

    void OnEnable() 
    {
        charController.Player.Enable();
    }
    void OnDisable() 
    {
        charController.Player.Disable();
    }
}
