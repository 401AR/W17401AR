using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyChange : MonoBehaviour {

    public Baby baby;
    private int currentColour = 0;

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
        ChangeColor();
	}

    public void ChangeColor()
    {
        if (baby.totalFindings() != currentColour)
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            currentColour = baby.totalFindings();
        }
    }
}
