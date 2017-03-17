using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class StartServerButton : MonoBehaviour {
    public Button StartServer;

    // Use this for initialization
    void Start () {
        Button btn = StartServer.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
    public void TaskOnClick() {
        Debug.Log("Starting server...");
        NetworkManager.singleton.StartServer();
        Debug.Log("Server running on port: " + NetworkManager.singleton.networkPort);
    }

}
