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

public class SlotItem : MonoBehaviour, IDropHandler
{
    public Image Preview;
    public Text Name;

    // This is defining properties for the item to be in slots and coming from slots
    public GameObject item
    {
        get
        {
            // If there is an item
            if (transform.childCount > 0) {
                // Return the item to the slot
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    //for the recieveing object
    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            // This executes when item dragged to slot
            DragHandler.itemBeingDragged.transform.SetParent(transform);
        }
    }
    #endregion
}
