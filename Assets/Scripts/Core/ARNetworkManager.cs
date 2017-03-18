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
 * ***************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class ARNetworkManager : NetworkManager
{
    public TextAsset iniFile;

    // FIXME: Correct to StartupServer.
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
        string ipAddress = readIni("Server", "IP", "localhost");
        singleton.networkAddress = ipAddress;
    }

    protected void SetPort() {
        string port = readIni("Server", "Port", "7777");
        singleton.networkPort = int.Parse(port);
    }

    // [FILE] must be provided without extension.
    // Write [VALUE] to [FILE], under [SECTION], at the entry identifed with [KEY]
    // Credit: https://www.assetstore.unity3d.com/en/#!/content/23706 
    public void writeIni(string section, string key, string value)
    {
        INIParser ini = new INIParser();

        ini.Open(iniFile);
        ini.WriteValue(section, key, value);
        ini.Close();

        Debug.Log("Wrote value: '" + value + "' " + section + ", " + key);
        return;
    }

    // Read [VALUE] from [FILE], under [SECTION], at the entry identifed with [KEY].  If no value can be read, return [DEFAULTVALUE].
    // Credit: https://www.assetstore.unity3d.com/en/#!/content/23706 
    public string readIni(string section, string key, string defaultValue)
    {
        INIParser ini = new INIParser();

        ini.Open(iniFile);
        string value = ini.ReadValue(section, key, defaultValue);
        ini.Close();

        Debug.Log("Received value: '" + value + "' from " + section + ", " + key);
        return value;
    }

}