using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinServerButton : MonoBehaviour {
    public Button JoinServer;

    // Use this for initialization
    void Start () {
        Button btn = JoinServer.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
    public void TaskOnClick() {
        Debug.Log("Starting client...");
        NetworkManager.singleton.StartClient();
        Debug.Log("Attempting to connect to " + NetworkManager.singleton.networkAddress + " : " + NetworkManager.singleton.networkPort);
    }

}
