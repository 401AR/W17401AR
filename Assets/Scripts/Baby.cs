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

    void addFinding(Finding newFinding) {
        // Only server can make (and push) changes to the baby.
        if (!isServer) {
            Debug.Log("Refused non-server attempt to addFinding.");
            return;
        }

        findings.Add(newFinding);
        Debug.Log("Finding added to baby.");
    }

    void removeFinding(Finding oldFinding) {
        // Only server can make (and push) changes to the baby.
        if (!isServer) {
            Debug.Log("Refused non-server attempt to removeFinding.");
            return;
        }

        findings.Remove(oldFinding);
        Debug.Log("Finding removed from baby.");
    }

    [SerializeField]
    public SyncList<Finding> findings;          // FIXME: This is public for testing only, it must be private after basic tests are completed.

}
