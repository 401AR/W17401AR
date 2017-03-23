using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	// this public static below needs to be the ColorItem list object
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		//here, this gameObject needs to be the list item 
		// (colorItem) that michael created
		// which is being dragged
		startPosition = transform.position;
		//used to determine if object has been dropped into a new slot
		startParent = transform.parent;
		//this canvas group holds all the drag location slots
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation
	// called every frame of a drag
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		}
	}

	#endregion




}
