using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
public class WsClient : MonoBehaviour
{

    [SerializeField]
    private Text laConsoleTexte;

    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://benoit.dectim.ca:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("aaMessage Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
            laConsoleTexte.text = "Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data;
        };
    }
    private void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send("Hello");
        }
    }
}