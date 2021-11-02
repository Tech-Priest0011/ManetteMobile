using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WebSocketSharp;

public class Jump : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler
{
    public string address;
    public string port; 

    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://" + address + ":" + port);   //Changer l'address et le port
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("aaMessage Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
        };
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public UnityEvent onHoldClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Jump");
        ws.Send("Jump");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Mouse Up");
    }

    
}
