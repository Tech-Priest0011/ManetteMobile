using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WebSocketSharp;

public class JoystickMessage : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Text laConsoleTexte;

    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://jbleau.dectim.ca:8081");   //Changer l'address et le port
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("aaMessage Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
            laConsoleTexte.text = "Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(pointerDown == true)
        {
            ws.Send("Go Up");
        }
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

    private bool pointerDown;
    public UnityEvent onHoldClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("Go foward");
        ws.Send("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        Debug.Log("Mouse Up");
        ws.Send("Mouse Up: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
    }
    
}
