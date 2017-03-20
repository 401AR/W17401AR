/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: IniHandler.cs
 * 
 * Description: Handles functions for handling loading Server information
 * from INI.
 * 
 * Credits: 
 * INI Handling credited: https://www.assetstore.unity3d.com/en/#!/content/23706
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniHandler : MonoBehaviour {

    public TextAsset iniFile;

    private static IniHandler _instance = null;
    public static IniHandler Instance { get { return _instance; } }

    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            // just move it to the root
            this.transform.parent = null;
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // [FILE] must be provided without extension.
    // Write [VALUE] to [FILE], under [SECTION], at the entry identifed with [KEY]
    // Credit: https://www.assetstore.unity3d.com/en/#!/content/23706 
    public void writeIni(string section, string key, string value)
    {
        INIParser ini = new INIParser();

        ini.Open(iniFile);
        ini.WriteValue(section, key, value);
        ini.Close();

        Debug.Log("Wrote value: '" + value + "' " + section + ", " + key);
        return;
    }

    // Read [VALUE] from [FILE], under [SECTION], at the entry identifed with [KEY].  If no value can be read, return [DEFAULTVALUE].
    // Credit: https://www.assetstore.unity3d.com/en/#!/content/23706 
    public string readIni(string section, string key, string defaultValue)
    {
        INIParser ini = new INIParser();

        ini.Open(iniFile);
        string value = ini.ReadValue(section, key, defaultValue);
        ini.Close();

        Debug.Log("Received value: '" + value + "' from " + section + ", " + key);
        return value;
    }

}
