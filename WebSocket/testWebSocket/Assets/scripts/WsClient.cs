using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
public class WsClient : MonoBehaviour
{
    public string address;
    public string port; 

    [SerializeField]
    private Text laConsoleTexte;
       
    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://" + address + ":" + port);   //Changer l'address et le port
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
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     ws.Send("Hello");
        // }
        
    }

    public void EnvoieMesage(float x, float y)
    {
        Debug.Log("----------X: " + x);
        Debug.Log("----------Y: " + y);

        ws.Send(x + " , " + y);
    }
}