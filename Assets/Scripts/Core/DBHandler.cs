using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public SimpleSQL.SimpleSQLManager dbManager;
    public List<SyncListFinding> getColors()
    {
        string sql = "SELECT * FROM Weapon";
        List<SyncListFinding> colors = dbManager.Query<SyncListFinding>(sql);
        return colors;
    }

}
