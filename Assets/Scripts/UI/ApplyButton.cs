/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: ApplyButton.cs
 * 
 * Description: Handles onClick event for Apply button.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyButton : MonoBehaviour {
    public Baby baby;
    public Button Apply;

    // Use this for initialization
    void Start () {
        Button btn = Apply.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
    // On click event handler
    public void TaskOnClick() {
        SyncListFinding test = new SyncListFinding();
        test.position.Set(1.0f, 0.0f, 0.0f);

        Debug.Log(baby);
        baby.addFinding(test, Location.core);

        Debug.Log(JsonUtility.ToJson(test));
        Debug.Log(baby.totalFindings());
    }

}
