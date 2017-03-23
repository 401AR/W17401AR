/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: ResetCoreButton.cs
 * 
 * Description: Handles onClick event for Reset Core button.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCoreButton : MonoBehaviour
{
    public Baby baby;
    public DropListController core;
    public Button resetCore;

    // Use this for initialization
    void Start() {
        Button btn = resetCore.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // On click event handler
    public void TaskOnClick() {
        core.clear();
    }

}
