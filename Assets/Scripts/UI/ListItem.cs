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

    // Set list item data from SyncListFinding
    public void setData(SyncListFinding data) {
        Name.text = data.name;

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

}
