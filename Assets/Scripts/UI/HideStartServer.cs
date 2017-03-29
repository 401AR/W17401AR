/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: HideStartServer.cs
 * 
 * Description: Hides "Start Server" button if the detected device is mobile.
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideStartServer : DetectMobile
{
    public Button start;

    // Use this for initialization
    void Start () {
		if (isMobile() == true) {
            Button btn = start.GetComponent<Button>();
            btn.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
