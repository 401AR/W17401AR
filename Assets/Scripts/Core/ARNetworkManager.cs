using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class ARNetworkManager : NetworkManager
{
    public void StartupHost()
    {
        SetPort();
        //SetName();
        Debug.Log("Server running on port: " + singleton.networkPort);
        singleton.StartHost();
    }

    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        //SetName();
        Debug.Log("Attempting to connect to " + singleton.networkAddress + " : " + singleton.networkPort);
        singleton.StartClient();
    }

    private void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
        singleton.networkAddress = ipAddress;
    }

    private void SetPort()
    {
        singleton.networkPort = 7777;
    }

}