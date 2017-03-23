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
using UnityEngine.UI;

public class TextureController : MonoBehaviour
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
        items = dbHandler.getTextures();

        // Erase previous childrens
        for (int i = 0; i < this.scroller.content.childCount; i++) {
            Destroy(scroller.content.GetChild(i).gameObject);
        }

        foreach (SyncListFinding texture in items) {
            var newTexture = Instantiate(ListItemPrefab) as ListItem;
            newTexture.transform.SetParent(this.scroller.content);
            newTexture.transform.localPosition = Vector3.zero;
            newTexture.transform.localScale = Vector3.one;
            newTexture.transform.localRotation = Quaternion.identity;
            newTexture.setData(texture);
        }
    }

    public void clear() {
        // Erase previous childrens
        for (int i = 0; i < this.scroller.content.childCount; i++) {
            Destroy(scroller.content.GetChild(i).gameObject);
        }

        items.Clear();
    }

    public int totalElements() {
        return items.Count;
    }

}
