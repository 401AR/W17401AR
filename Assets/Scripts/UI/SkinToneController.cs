/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: SkinToneController.cs
 * 
 * Description: Provides handling of dynamic content for (skin tone) scroll lists.
 * Credits: http://www.folio3.com/blog/creating-dynamic-scrollable-lists-with-new-unity-canvas-ui/
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinToneController : MonoBehaviour
{
    public DBHandler dbHandler;
    public ScrollRect scroller;
    public ListItem ListItemPrefab;

    protected List<SyncListFinding> items;

    void Start() {
        items = new List<SyncListFinding>();
        populate();
    }

    public void populate() {
        items = dbHandler.getColors();

        // Erase previous childrens
        for (int i = 0; i < this.scroller.content.childCount; i++) {
            Destroy(scroller.content.GetChild(i).gameObject);
        }

        foreach (SyncListFinding color in items) {
            var newColor = Instantiate(ListItemPrefab) as ListItem;
            newColor.transform.SetParent(scroller.content);
            newColor.transform.localPosition = Vector3.zero;
            newColor.transform.localScale = Vector3.one;
            newColor.transform.localRotation = Quaternion.identity;
            newColor.setData(color);
        }
    }

    public void clear() {
        // Erase previous childrens
        for (int i = 0; i < this.scroller.content.childCount; i++)
        {
            Destroy(scroller.content.GetChild(i).gameObject);
        }

        items.Clear();
    }

    public int totalElements() {
        return items.Count;
    }

}
