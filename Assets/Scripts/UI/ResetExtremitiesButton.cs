/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: ResetExtremitiesButton.cs
 * 
 * Description: Handles onClick event for Reset Extremities button.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetExtremitiesButton : MonoBehaviour
{
    public Baby baby;
    public DropListController extremities;
    public Button resetExtremities;

    // Use this for initialization
    void Start() {
        Button btn = resetExtremities.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // On click event handler
    public void TaskOnClick() {
        extremities.clear();
    }

}
