/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: DropListController.cs
 * 
 * Description: Provides handling of dynamic content for DropListController.
 * Credits: http://www.folio3.com/blog/creating-dynamic-scrollable-lists-with-new-unity-canvas-ui/
 * Credits: http://www.zesix.com/?p=3651
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

    public List<SyncListFinding> items;
    public List<ListItem> itemPrefabs;

    void Start() {
        items = new List<SyncListFinding>();
    }

    public void add(SyncListFinding newFinding) {
        
        // Restrict color findings to one active color at a time.
        if (newFinding.colorJson != "0") {
            clear();
        }

        ListItem newPrefab = Instantiate(ListItemPrefab) as ListItem;
        newPrefab.transform.SetParent(scroller.content);
        newPrefab.transform.localPosition = Vector3.zero;
        newPrefab.transform.localScale = Vector3.one;
        newPrefab.transform.localRotation = Quaternion.identity;
        newPrefab.setData(newFinding);
        
        itemPrefabs.Add(newPrefab);
        items.Add(newFinding);
    }

    public void clear() {
        // Erase previous childrens
        for (int i = 0; i < this.scroller.content.childCount; i++) {
            Destroy(scroller.content.GetChild(i).gameObject);
        }

        itemPrefabs.Clear();
        items.Clear();
    }

    public void highlight(int highLightId) {
        
        // Only one finding can be added at a time.  Therefore, any previous findings must be de-selected.
        for (int i = 0; i < itemPrefabs.Count; i++) {
            if ( i == (highLightId - 1) ) {
                itemPrefabs[i].select();
            }
            else {
                itemPrefabs[i].deselect();
            }

        }
    }

    public int totalElements() {
        return items.Count;
    }
}
