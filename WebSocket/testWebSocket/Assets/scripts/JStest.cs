using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WebSocketSharp;

public class JStest : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
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

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Begin");
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging: Move stick");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Ended");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public UnityEvent onHoldClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Mouse Up: ");
    }
    
}
