using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBHandler : MonoBehaviour {
    public SimpleSQL.SimpleSQLManager dbManager;

    // Return all Color Findings
    public List<SyncListFinding> getColors()
    {
        string sql = "SELECT * FROM Findings WHERE colorJson IS NOT NULL;";
        List<SyncListFinding> colors = dbManager.Query<SyncListFinding>(sql);
        return colors;
    }

    // Return all Texture Findings
    public List<SyncListFinding> getTextures()
    {
        string sql = "SELECT * FROM Findings WHERE TexturePath IS NOT NULL;";
        List<SyncListFinding> textures = dbManager.Query<SyncListFinding>(sql);
        return textures;
    }

}
