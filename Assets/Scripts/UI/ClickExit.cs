/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: ClickExit.cs
 * 
 * Description: Provides handling for Exit button.  Every program needs an
 * exit button to avoid alienating users.
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickExit : MonoBehaviour {
    public Button exitButton;

    // Use this for initialization
    void Start() {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // On click event handler
    public void TaskOnClick() {
        Application.Quit();
    }
}
