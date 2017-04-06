/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: ConnectionTester.cs
 * 
 * Description: Handles automated testing of connection.  To be used before
 * actually connecting, to give client and trouble-shooting feedback for
 * connection failure.
 * 
 * Credits: http://gamedevdocket.blogspot.ca/2015/04/check-for-network-connection-unity3d.html
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ConnectionTester : MonoBehaviour {
    public UnityEngine.UI.Text testResults;
    public float pingTimeout;

    private static ConnectionTester _instance = null;
    public static ConnectionTester Instance { get { return _instance; } }

    // Use this for initialization
    void Start() {
        
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // just move it to the root
            this.transform.parent = null;
            _instance = this;
        }


        DontDestroyOnLoad(this.gameObject);
    }

    // Call this to do a ping check.
    public void StartPing() {
        string serverIP = GetServerIP();
        StartCoroutine(Ping(serverIP));
    }

    // Ping against Server.  Is true, then we are either on the same network
    // or both public.
    protected IEnumerator Ping(string serverIP) {
        Ping ping = new Ping(serverIP);
        float startTime = Time.time;

        // Ping can be time consuming.

        if (testResults == null) {
            // References are lost when reloading scenes.  They must be reconnected to avoid breaking scripts.
            testResults = GameObject.FindWithTag("Error Message").GetComponent<Text>();
        }

        testResults.text = "Checking network...";
        while (!ping.isDone && Time.time < startTime + pingTimeout) {
            yield return new WaitForSeconds(0.1f);
        }

        if (ping.isDone) {
            // It is possible for testResults to be destroyed after completing test before this triggers.
            if (testResults != null) {
                testResults.text = "Network available.";
            }
        }
        else {
            // It is possible for testResults to be destroyed after completing test before this triggers.
            if (testResults != null) {
                testResults.text = "No network.";
            }
        }
    }

    protected string GetServerIP() {
        return IniHandler.Instance.readIni("Server", "IP", "localhost");
    }

    protected string GetServerPort() {
        return IniHandler.Instance.readIni("Server", "Port", "7777");
    }
}
