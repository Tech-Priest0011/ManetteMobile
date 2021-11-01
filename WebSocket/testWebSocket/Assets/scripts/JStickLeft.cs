using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WebSocketSharp;

public class JStickLeft : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
        }

if(pointerDown == true)
{
    Camera.main.backgroundColor = new Color (Random.Range (0f, 1f), Random.Range(0f,1f), Random.Range(0f,1f));
}
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Begin");
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging: Move stick");
        ws.Send("Dragging: Move stick");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Ended");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        ws.Send("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

private bool pointerDown;
public UnityEvent onHoldClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        Camera.main.backgroundColor = new Color (Random.Range (0f, 1f), Random.Range(0f,1f), Random.Range(0f,1f));
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
    }
    
}
