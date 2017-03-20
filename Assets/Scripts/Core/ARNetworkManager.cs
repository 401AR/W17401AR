/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: ARNetworkManager.cs
 * 
 * Description: Wraps NetworkManager and adds functions for handling loading
 * Server information from INI.
 * 
 * Credits: 
 * INI Handling credited: https://www.assetstore.unity3d.com/en/#!/content/23706 
 * hostId trick: https://forum.unity3d.com/threads/i-forgot-how-to-detect-player-client-server-disconnection-anyone-can-tell-me.358433/
 * ***************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class ARNetworkManager : NetworkManager
{   
    public void PreStartServer() {
        SetServerPort();
        ConnectionTester.Instance.StartPing();

        Debug.Log("Server running on port: " + singleton.networkPort);
        singleton.StartHost();      // singleton.StartServer();
    }

    public void PreJoinServer() {
        SetServerIP();
        SetServerPort();
        ConnectionTester.Instance.StartPing();

        Debug.Log("Attempting to connect to " + singleton.networkAddress + " : " + singleton.networkPort);
        singleton.StartClient();
    }

    public override void OnServerConnect(NetworkConnection conn) {
        // hostId = -1 for localhost, 0 is server. https://forum.unity3d.com/threads/i-forgot-how-to-detect-player-client-server-disconnection-anyone-can-tell-me.358433/
        if(conn.hostId >= 0) {
            Debug.Log("New client connected");
        }

        base.OnServerConnect(conn);
    }

    public override void OnServerDisconnect(NetworkConnection conn) {
        Debug.Log("Connection to server terminated");
        base.OnServerDisconnect(conn);
    }

    protected void SetServerIP() {
        string ipAddress = IniHandler.Instance.readIni("Server", "IP", "localhost");
        singleton.networkAddress = ipAddress;
    }

    protected void SetServerPort() {
        string port = IniHandler.Instance.readIni("Server", "Port", "7777");
        singleton.networkPort = int.Parse(port);
    }

}