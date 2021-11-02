using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Retriver : MonoBehaviour
{
    void Start() {
        StartCoroutine(GetText());
    }

    public string address;
    public string port; 
 
    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get(address + ":" + port);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}
