/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: DisconnectButton.cs
 * 
 * Description: Provides handling of the "OFF" button in Multiplayer.scene.  Visible
 * only to Trainer.
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisconnectButton : MonoBehaviour {
    public Button ONOFFButton;

    // Use this for initialization
    void Start()
    {
        Button btn = ONOFFButton.GetComponent<Button>();
        btn.onClick.AddListener(NetworkManager.singleton.StopHost);

    }

}
