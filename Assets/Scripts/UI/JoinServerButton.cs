/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: JoinServerButton.cs
 * 
 * Description: Handles onClick event for Join Server button.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinServerButton : MonoBehaviour {
    public ARNetworkManager network;
    public Button Join;

    // Use this for initialization
    void Start () {
        Button btn = Join.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
    // OnClick event handler
    public void TaskOnClick() {
        Debug.Log("Starting client...");
        network.JoinGame();
        Debug.Log("Attempting to connect to " + network.networkAddress + " : " + network.networkPort);
    }

}
