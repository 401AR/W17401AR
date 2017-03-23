/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: DropListController.cs
 * 
 * Description: Provides handling of dynamic content for DropListController.
 * Credits: http://www.folio3.com/blog/creating-dynamic-scrollable-lists-with-new-unity-canvas-ui/
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropListController : MonoBehaviour
{
    public DBHandler dbHandler;
    public ScrollRect scroller;
    public ListItem ListItemPrefab;

    protected List<SyncListFinding> items;

    void Start() {
        items = new List<SyncListFinding>();
    }

    public void add(SyncListFinding newFinding) {
        ListItem newColor = Instantiate(ListItemPrefab) as ListItem;
        newColor.transform.SetParent(scroller.content);
        newColor.transform.localPosition = Vector3.zero;
        newColor.transform.localScale = Vector3.one;
        newColor.transform.localRotation = Quaternion.identity;
        newColor.setData(newFinding);
    }

    public void clear() {

    }

    public int totalElements() {
        return items.Count;
    }
}
