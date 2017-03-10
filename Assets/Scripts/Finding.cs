/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: Finding.cs
 * 
 * Description: Base class that can hold data for any Finding.  To simplify
 * use with SyncList.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SyncListFinding {

    public Vector3 position;
    public int size;

    // TODO: Private variables regarding texture go here.
    private Color tint;     // Tint to apply to baby skin color.
}
