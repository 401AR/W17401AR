using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class ARNetworkManager : NetworkManager
{
    public void StartupHost() {
        SetPort();
        Debug.Log("Server running on port: " + singleton.networkPort);
        singleton.StartHost();
    }

    public void JoinGame() {
        SetIPAddress();
        SetPort();
        Debug.Log("Attempting to connect to " + singleton.networkAddress + " : " + singleton.networkPort);
        singleton.StartClient();
    }

    protected void SetIPAddress() {
        IniHandler ini = new IniHandler();
        string ipAddress = ini.read("config.ini", "Server", "IP", "localhost");
        singleton.networkAddress = ipAddress;
    }

    protected void SetPort() {
        IniHandler ini = new IniHandler();
        string port = ini.read("config.ini", "Server", "Port", "7777");
        singleton.networkPort = int.Parse(port);
    }

}