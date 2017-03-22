using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleSQL;

public class DBHandler : MonoBehaviour {
    public SimpleSQL.SimpleSQLManager dbManager;

    // Return all Color Findings
    public List<SyncListFinding> getColors()
    {
        SimpleDataTable table = dbManager.QueryGeneric("SELECT * FROM SyncListFinding WHERE colorJson <> 0");
        Debug.Log("Query Results: Row Count = " + table.rows.Count);

        List<SyncListFinding> colors = new List<SyncListFinding>();
        foreach (SimpleDataRow row in table.rows)
        {
            SyncListFinding item = new SyncListFinding();
            item.id = int.Parse(row.fields[0].ToString());
            item.name = row.fields[1].ToString();
            item.colorJson = row.fields[2].ToString();
            item.texturePath = row.fields[3].ToString();

            colors.Add(item);
            Debug.Log("Item added: id = " + item.id + ", name: " + item.name + ", color: " + item.colorJson + ", texture: " + item.texturePath);
        }

        return colors;
    }

    // Return all Texture Findings
    public List<SyncListFinding> getTextures()
    {
        SimpleDataTable table = dbManager.QueryGeneric("SELECT * FROM SyncListFinding WHERE TexturePath <> 0");
        Debug.Log("Query Results: Row Count = " + table.rows.Count);

        List<SyncListFinding> textures = new List<SyncListFinding>();
        foreach (SimpleDataRow row in table.rows)
        {
            SyncListFinding item = new SyncListFinding();
            item.id = int.Parse(row.fields[0].ToString());
            item.name = row.fields[1].ToString();
            item.colorJson = row.fields[2].ToString();
            item.texturePath = row.fields[3].ToString();

            textures.Add(item);
            Debug.Log("Item added: id = " + item.id + ", name: " + item.name + ", color: " + item.colorJson + ", texture: " + item.texturePath);
        }

        return textures;
    }

}
