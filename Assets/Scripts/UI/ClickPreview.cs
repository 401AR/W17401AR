/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: ClickPreview.cs
 * 
 * Description: Provides position handling based on where on a baby body part
 * is clicked.
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPreview : MonoBehaviour {
    public Button babyPreview;

    // Use this for initialization
    void Start() {
        Button btn = babyPreview.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        name = btn.name;
    }

    // On click event handler
    public void TaskOnClick() {
        Vector2 mousePos = Input.mousePosition;
        Vector3 worldPos = new Vector3(mousePos.x, mousePos.y, 0.0f);
        FindingClickHandler.Instance.setPosition(name, worldPos);
    }
}
