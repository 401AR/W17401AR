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
using SimpleSQL;

[System.Serializable]
public class SyncListFinding {
    [PrimaryKey]
    public int id;

    [Indexed, MaxLength(60), NotNull]
    public string name;

    public string colorJson;
    public string texturePath;

    // Tracking vars.
    public Vector3 position;
    public int size;


    public Color getColor() {
        return JsonUtility.FromJson<Color>(colorJson);
    }

    // TODO: Size will be used to track the size of a texture finding applied to a baby (ie. small rash, big rash).  So be in radius?
}
