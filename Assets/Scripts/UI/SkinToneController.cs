/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: SkinToneController.cs
 * 
 * Description: Provides handling of dynamic content for SkinToneController.
 * Credits: http://www.folio3.com/blog/creating-dynamic-scrollable-lists-with-new-unity-canvas-ui/
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinToneController : MonoBehaviour
{
    public DBHandler dbHandler;
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    protected List<SyncListFinding> colors;

    void Start()
    {

        populate();

    }

    public void populate()
    {

        colors = dbHandler.getColors();

        // 2. Iterate through the data, 
        //	  instantiate prefab, 
        //	  set the data, 
        //	  add it to panel
        foreach (SyncListFinding color in colors) {
            GameObject newColor = Instantiate(ListItemPrefab) as GameObject;
            SlotItem controller = newColor.GetComponent<SlotItem>() as SlotItem;
            controller.Preview.color = color.getColor();
            controller.Name.text = color.name;
            newColor.transform.SetParent(ContentPanel.transform, false);
            newColor.transform.localScale = Vector3.one;
            Debug.Log("Added color: Name: " + color.name + " Color: " + color.getColor().ToString());
        }
    }

}
