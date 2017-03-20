/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: StartServerButton.cs
 * 
 * Description: Handles onClick event for Start Server button.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class StartServerButton : MonoBehaviour {
    public ARNetworkManager network;
    public Button StartServer;

    // Use this for initialization
    void Start () {
        Button btn = StartServer.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
    // Handle on click event
    public void TaskOnClick() {
        Debug.Log("Starting server...");
        network.PreStartServer();
        Debug.Log("Server running on port: " + network.networkPort);
    }

}
