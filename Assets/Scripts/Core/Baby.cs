/******************************************************************************
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

public enum Location
{
    core = 0,
    extremity = 1
};

public class Baby : NetworkBehaviour {

    [SerializeField]
    public SyncListString coreFindings;             // FIXME: This is public for testing only, it must be private after basic tests are completed.

    [SerializeField]
    public SyncListString extremityFindings;        // FIXME: This is public for testing only, it must be private after basic tests are completed.

                                                    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        coreFindings = new SyncListString();
        extremityFindings = new SyncListString();
    }

    public void addFinding(SyncListFinding newFinding, Location location) {
        // Only server can make (and push) changes to the baby.
        if (!isServer)
        {
            Debug.Log("Refused non-server attempt to addFinding.");
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
                Debug.Log("Bad location type was specified.  Rejecting finding.");
                break;
        }

        Debug.Log("Finding added to baby.");
    }

    public void removeFinding(SyncListFinding oldFinding, Location location) {
        // Only server can make (and push) changes to the baby.
        if (!isServer) {
            Debug.Log("Refused non-server attempt to removeFinding.");
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
                Debug.Log("Bad location type was specified.  Rejected deletion of finding.");
                break;
        }
        
        Debug.Log("Finding removed from baby.");
    }
    
    public void clearFindings(Location location) {
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
                Debug.Log("Bad location type was specified.  Rejected clearing findings.");
                break;
        }
    }

    public void clearAllFindings() {
        clearFindings(Location.core);
        clearFindings(Location.extremity);
    }

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
                Debug.Log("Bad location type was specified.  Rejected count of findings.");
                break;
        }

        return count;
    }

    public int totalFindings() { return (totalFindings(Location.core) + totalFindings(Location.extremity)); }

}
