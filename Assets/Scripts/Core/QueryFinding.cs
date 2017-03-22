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
public class QueryFinding {
    [PrimaryKey]
    public int id;

    [Indexed, MaxLength(60), NotNull]
    public string name;

    public string colorJson;
    public string texturePath;

    public Color getColor()
    {
        return JsonUtility.FromJson<Color>(colorJson);
    }
}
