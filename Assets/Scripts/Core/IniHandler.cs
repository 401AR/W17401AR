/******************************************************************************
* Author: Michael Morris
* Course: CMPUT401 AR
* File: IniHandler.cs
* 
* Description: Wrapper class for free Unity package 
* Credit: https://www.assetstore.unity3d.com/en/#!/content/23706 
* ***************************************************************************/
using System;
using UnityEngine;
using UnityEditor.iOS;

public class IniHandler
{
    // Write [VALUE] to [FILE], under [SECTION], at the entry identifed with [KEY]
	public void write(string file, string section, string key, string value) {
        INIParser ini = new INIParser();
        TextAsset asset = Resources.Load(file) as TextAsset;

        ini.Open(asset);
        ini.WriteValue(section, key, value);
        ini.Close();

        Debug.Log("Wrote value: '" + value + "' to " + file + ", " + section + ", " + key);
        return;
    }

    // Read [VALUE] from [FILE], under [SECTION], at the entry identifed with [KEY].  If no value can be read, return [DEFAULTVALUE].
    public string read(string file, string section, string key, string defaultValue) {
        INIParser ini = new INIParser();
        UnityEngine.TextAsset asset = Resources.Load(file) as TextAsset;

        ini.Open(asset);
        string value = ini.ReadValue(section, key, defaultValue);
        ini.Close();

        Debug.Log("Received value: '" + value + "' from " + file + ", " + section + ", " + key);
        return value;
    }
}
