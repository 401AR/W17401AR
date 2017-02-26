/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: Finding.cs
 * 
 * Description: Base class extended by ColorFinding and TextureFinding.
 * Allows storage of all findings under one collection.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finding : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private Vector3 position;
    private int size;           // TODO: int may not be sufficient for sizing.
}
