using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingClickHandler : MonoBehaviour {

    public SyncListFinding currentFinding;
    public DropListController coreDropList;
    public DropListController extremityDropList;


    private static FindingClickHandler _instance = null;
    public static FindingClickHandler Instance { get { return _instance; } }

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

    public void setCurrentFinding(SyncListFinding finding) {
        currentFinding = finding;
    }

    public void setPosition(Vector3 position) {
        // A finding must be selected before setting position.
        if (currentFinding == null) { return; }

        currentFinding.position = position;     // FIXME: This really needs to assign an appropriate position on the baby model.
        Location destination = sortFinding();

        addToList(destination);
    }

    public Location sortFinding() {
        Location sortedLocation = Location.core; //Location.invalid;

        // IF POSITION BETWEEN ___ AND ____ THEN IS CORE
        // IF POSITION BETWEEN ___ AND ____ THEN IS EXTREMITY
        
        return sortedLocation;
    }

    public void addToList(Location destination) {

        switch (destination)
        {
            case Location.core:
                coreDropList.add(currentFinding);
                break;
            case Location.extremity:
                extremityDropList.add(currentFinding);
                break;
            default:
                Debug.LogError("Bad location type was specified.  Unable to add finding to drop list.");
                break;
        }

        currentFinding = null;
    }

}
