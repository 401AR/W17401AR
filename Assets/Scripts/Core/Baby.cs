﻿/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: Baby.cs
 * 
 * Description: Clients and Server share one baby object.  The Server pushes
 * changes to the baby, and these changes are visible to both the Server and 
 * the Clients.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

// Add one for each location listbox.
public enum Location
{
    core = 0,
    extremity = 1,
    invalid = 255
};

public class Baby : NetworkBehaviour {
    
    [SerializeField]
    public SyncListString coreFindings;             // FIXME: This is public for testing only, it must be private after basic tests are completed.

    [SerializeField]
    public SyncListString extremityFindings;        // FIXME: This is public for testing only, it must be private after basic tests are completed.

    public GameObject babyBody;
    public GameObject babyHead;

    // Override client instantiation to add hooks for finding updates.
    public override void OnStartClient() {
        coreFindings.Callback = onChangeFindings;
        extremityFindings.Callback = onChangeFindings;
        base.OnStartClient();
    }

    void Awake()  {
        coreFindings = new SyncListString();
        extremityFindings = new SyncListString();
    }

    public void onChangeFindings(SyncListString.Operation op, int index) {
        /*if (isServer) {
            Debug.Log("Refused server attempt to update client UI.");
            return;
        }*/

        Debug.Log("UPDATE BABY AR HERE");

        if (coreFindings.Count > 0)
        {
            babyBody.GetComponent<BabyChange>().ChangeColor(coreFindings[0]);
            babyHead.GetComponent<BabyChange>().ChangeColor(coreFindings[0]);
        }

        printFindings();
    }

    // Apply a new finding to the Baby.
    public void addFinding(SyncListFinding newFinding, Location location) {
        // Only server can make (and push) changes to the baby.
        if (!isServer) {
            Debug.LogError("Refused non-server attempt to addFinding.");
            return;
        }

        string findingJson = JsonUtility.ToJson(newFinding);

        switch(location)
        {
            case Location.core:
                coreFindings.Add(findingJson);
                
                break;
            case Location.extremity:
                extremityFindings.Add(findingJson);
                break;
            default:
                Debug.LogError("Bad location type was specified.  Rejecting finding.");
                break;
        }

        Debug.Log("Finding added to baby.");
    }

    // Remove a specific finding from the baby.
    public void removeFinding(SyncListFinding oldFinding, Location location) {
        // Only server can make (and push) changes to the baby.
        if (!isServer) {
            Debug.LogError("Refused non-server attempt to removeFinding.");
            return;
        }

        string findingJson = JsonUtility.ToJson(oldFinding);

        switch (location)
        {
            case Location.core:
                coreFindings.Add(findingJson);
                break;
            case Location.extremity:
                extremityFindings.Add(findingJson);
                break;
            default:
                Debug.LogError("Bad location type was specified.  Rejected deletion of finding.");
                break;
        }

        Debug.Log("Finding removed from baby.");
    }
    
    // Remove all objects in a particular location from the baby.
    public void clearFindings(Location location) {
        // Only server can make (and push) changes to the baby.
        if (!isServer) {
            Debug.Log("Refused non-server attempt to clear Findings.");
            return;
        }

        switch (location)
        {
            case Location.core:
                coreFindings.Clear();
                Debug.Log("Core Findings cleared");
                break;
            case Location.extremity:
                extremityFindings.Clear();
                Debug.Log("Extremity Findings cleared");
                break;
            default:
                Debug.LogError("Bad location type was specified.  Rejected clearing findings.");
                break;
        }

        Debug.Log("Findings cleared from baby.");
    }

    // Remove all findings from the baby.
    public void clearAllFindings() {
        clearFindings(Location.core);
        clearFindings(Location.extremity);

        // Client update is called within each clearFindings.
    }

    // Check a specific finding is in a specific location.
    public bool findingContains(string finding, Location location)
    {
        bool contains = false;

        switch (location)
        {
            case Location.core:
                contains = coreFindings.Contains(finding);
                break;
            case Location.extremity:
                contains = extremityFindings.Contains(finding);
                break;
        }

        return contains;
    }

    // Get total number of findings in a specific location.
    public int totalFindings(Location location)
    {
        int count = -1;

        switch (location)
        {
            case Location.core:
                count = coreFindings.Count;
                break;
            case Location.extremity:
                count = extremityFindings.Count;
                break;
            default:
                Debug.LogError("Bad location type was specified.  Rejected count of findings.");
                break;
        }

        return count;
    }

    // Get total number of findings across all locations.
    public int totalFindings() { return (totalFindings(Location.core) + totalFindings(Location.extremity)); }

    protected void printFindings() {

        Debug.Log("Core Findings: ");
        foreach (string finding in coreFindings) {
            Debug.Log(finding);
        }

        Debug.Log("Extremity Findings: ");
        foreach (string finding in extremityFindings) {
            Debug.Log(finding);
        }

        return;
    }
}
