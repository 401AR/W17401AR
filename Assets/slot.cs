using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//this script might also need to be a component of the ColorItem list items
//dont want to mess with that rn

public class slot : MonoBehaviour, IDropHandler {
	//this has to be the colorItem from the list, probably needs to change
	//this is defining properties for the item to be in slots and coming from slots
	public GameObject item {
		get {
			// if there is an item
			if (transform.childCount>0) {
				// return the item to the slot
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	//for the recieving object
	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if(!item) {
			//if we already have an skin tone item, we dont want to accept an item
			//this executes when item dragged to slot
			DragHandler.itemBeingDragged.transform.SetParent (transform);
		}
	}
	#endregion
}
