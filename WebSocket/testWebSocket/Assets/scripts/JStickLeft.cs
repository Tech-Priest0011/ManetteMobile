using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WebSocketSharp;

public class JStickLeft : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler
{
    public string address;
    public string port; 
    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://" + address + ":" + port);    //Changer l'address et le port
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("aaMessage Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(pointerDown == true)
        {
            ws.Send("Go Left");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    private bool pointerDown;
    public UnityEvent onHoldClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("Go Left");
        ws.Send("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        Debug.Log("Mouse Up");
        ws.Send("Mouse Up: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
    
}
