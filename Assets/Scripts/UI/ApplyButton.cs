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
    public DropListController core;
    public DropListController extremities;
    public Button Apply;

    // Use this for initialization
    void Start () {
        Button btn = Apply.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
    // On click event handler
    public void TaskOnClick() {

        Debug.Log(baby);

        baby.clearAllFindings();

        foreach (SyncListFinding item in core.items) {
            baby.addFinding(item, Location.core);
            Debug.Log(JsonUtility.ToJson(item));
        }

        foreach (SyncListFinding item in extremities.items) {
            baby.addFinding(item, Location.extremity);
            Debug.Log(JsonUtility.ToJson(item));
        }
        
        Debug.Log(baby.totalFindings());
    }

}
