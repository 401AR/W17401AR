/******************************************************************************
 * Author: Christopher Hegberg
 * Course: CMPUT401 AR
 * File: BabyChange.cs
 * 
 * Description: Get changes made by server and updates baby model as a result.
 * 
 * ***************************************************************************/
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

	}

    public void CorrectOffset()
    {
        Vector3 temp = Vuforia.DeviceTrackerARController.DEFAULT_HEAD_PIVOT;
        //Vuforia.MixedRealityController.Mode.ROTATIONAL_VIEWER_AR;
    }

    public void ChangeColor(string newColor)
    {
        //Debug.Log(newColor + " made it");

        bool colorSection = false;
        float convertedNumberR = -1;
        float convertedNumberG = -1;
        float convertedNumberB = -1;
        float convertedNumberA = -1;
        for (int i = 0; i < newColor.Length; ++i ) {
            //Debug.Log(newColor[i]);
            if (newColor[i] == 'n' && i > 9)
            {
                if (newColor[i-8] == 'c' && newColor[i - 7] == 'o' && newColor[i - 6] == 'l' && newColor[i - 5] == 'o' &&
                    newColor[i - 4] == 'r' && newColor[i - 3] == 'J' && newColor[i - 2] == 's' && newColor[i - 1] == 'o')
                {
                    //Debug.Log("colorJson");
                    colorSection = true;
                }
            }
            if (newColor[i] == 'r' && colorSection)
            {
                convertedNumberR = TryConversionIntToString(i, newColor);
            }
            else if (newColor[i] == 'g' && colorSection)
            {
                convertedNumberG = TryConversionIntToString(i, newColor);
            }
            else if (newColor[i] == 'b' && colorSection)
            {
                convertedNumberB = TryConversionIntToString(i, newColor);
            }
            else if (newColor[i] == 'a' && colorSection)
            {
                convertedNumberA = TryConversionIntToString(i, newColor);
                colorSection = false;
                Debug.Log(convertedNumberR + " " + convertedNumberG + " " + convertedNumberB + " " + convertedNumberA);
            }
        }

        if (convertedNumberR != -1 && convertedNumberG != -1 && convertedNumberB != -1 && convertedNumberA != -1)
        {
            Debug.Log("Baby Changed color");
            GetComponent<Renderer>().material.color = new Color(convertedNumberR, convertedNumberG, convertedNumberB, convertedNumberA);
        }
    }

    private float TryConversionIntToString(int i, string newColor)
    {

        float convertedNumber = 0;
        string stringToConvert = newColor[i + 4].ToString() + newColor[i + 5].ToString() +
            newColor[i + 6].ToString() + newColor[i + 7].ToString();

        try
        {
            convertedNumber = float.Parse(stringToConvert);
            //Debug.Log("converted " + stringToConvert + " " + convertedNumberR);
        }
        catch
        {
            stringToConvert = newColor[i + 4].ToString() + newColor[i + 5].ToString() +
            newColor[i + 6].ToString();

            try
            {
                convertedNumber = float.Parse(stringToConvert);
                //Debug.Log("converted 2 " + stringToConvert + " " + convertedNumberR);
            }
            catch
            {
                Debug.Log("Wrong conversion");
            }
        }

        return convertedNumber;
    }
}
