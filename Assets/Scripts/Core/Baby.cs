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

public class Baby : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        findings = new SyncListString();
    }

    public void addFinding(SyncListFinding newFinding) {
        // Only server can make (and push) changes to the baby.
        if (!isServer)
        {
            Debug.Log("Refused non-server attempt to addFinding.");
            return;
        }

        string findingJson = JsonUtility.ToJson(newFinding);
        
        findings.Add(findingJson);
        Debug.Log("Finding added to baby.");
    }

    public void removeFinding(SyncListFinding oldFinding) {
        // Only server can make (and push) changes to the baby.
        if (!isServer) {
            Debug.Log("Refused non-server attempt to removeFinding.");
            return;
        }

        string findingJson = JsonUtility.ToJson(oldFinding);

        findings.Remove(findingJson);
        Debug.Log("Finding removed from baby.");
    }

    [SerializeField]
    public SyncListString findings;          // FIXME: This is public for testing only, it must be private after basic tests are completed.

    public int amountOfFindings()
    {
        return findings.Count;
    }
}
