/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: DetectMobile.cs
 * 
 * Description: Decides whether the current instance is run by the client
 * or server based on their runtime platform.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMobile : MonoBehaviour {

    // Generalize for the sake of product growth.
    public bool isMobile() {
        bool mobile = false;

        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                mobile = true;
                break;
            case RuntimePlatform.IPhonePlayer:
                mobile = true;
                break;
        };

        if (mobile == true) {
            Debug.Log("Log: RuntimePlatform is mobile.");
        }

        return mobile;
    }

    // Generalize for the sake of product growth.
    public bool isServer() {
        bool server = false;

        switch(Application.platform)
        {
            case RuntimePlatform.LinuxPlayer:
                server = true;
                break;
            case RuntimePlatform.OSXPlayer:
                server = true;
                break;
            case RuntimePlatform.WindowsPlayer:
                server = true;
                break;
        };

        if (server == true) {
            Debug.Log("Log: RuntimePlatform is a server.");
        }

        return server;
    }

}
