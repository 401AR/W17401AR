/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: SkinToneItem.cs
 * 
 * Description: Provides access to dynamic item controls for slot items.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ListItem : MonoBehaviour
{
    public Image Preview;
    public Text Name;
    public Toggle Entry;

    private SyncListFinding data;

    // Set list item data from SyncListFinding
    public void setData(SyncListFinding data) {
        Name.text = data.name;
        this.data = data;

        // Processing differs based on texture / color loading.
        if (data.texturePath != "0") {
            Preview.sprite = Resources.Load<Sprite>(data.texturePath);
        }
        else {
            Preview.color = data.getColor();
        }

        // Keep logging specific (not agnostic).
        if (data.texturePath != "0") {
            Debug.Log("Added finding: Name: " + data.name + " Texture: " + data.texturePath);
        }
        else {
            Debug.Log("Added finding: Name: " + data.name + " Color: " + data.colorJson);
        }

    }

    // Highlight this button
    public void select() {
        Entry.isOn = true;
    }

    // Remove highlight on this button.
    public void deselect() {
        Entry.isOn = false;
    }

    // Use this for initialization
    void Start() {
        Toggle btn = Entry.GetComponent<Toggle>();
        btn.onValueChanged.AddListener((value) => {
            TaskOnValueChanged(value);
        }
        );
    }

    // On click event handler
    public void TaskOnValueChanged(bool newState) {
        if (newState == true) {
            FindingClickHandler.Instance.setCurrentFinding(this.data);
            Entry.isOn = !Entry.isOn;

            //parentList.highlight(data.id);
            Debug.Log("You clicked me!");
        }
    }

    // Clear selection before destroying.
    private void OnDestroy() {
        deselect();
    }


}
