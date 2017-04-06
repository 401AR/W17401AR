using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Overlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
