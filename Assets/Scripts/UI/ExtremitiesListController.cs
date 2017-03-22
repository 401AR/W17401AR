/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: ExtremitiesListController.cs
 * 
 * Description: Provides handling of dynamic content for ExtremitiesListController.
 * Credits: http://www.folio3.com/blog/creating-dynamic-scrollable-lists-with-new-unity-canvas-ui/
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremitiesListController : MonoBehaviour
{
    public DBHandler dbHandler;
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    protected List<SyncListFinding> findings;

    void Start() {
        findings = new List<SyncListFinding>();
    }

    public void add(SyncListFinding newFinding) {
        GameObject newTexture = Instantiate(ListItemPrefab) as GameObject;
        SlotItem controller = newTexture.GetComponent<SlotItem>() as SlotItem;

        // Processing differs based on texture / color loading.
        if (newFinding.texturePath != "0") {
            controller.Preview.sprite = Resources.Load<Sprite>(newFinding.texturePath);
        }
        else {
            controller.Preview.color = newFinding.getColor();
        }

        controller.Name.text = newFinding.name;
        newTexture.transform.SetParent(ContentPanel.transform, false);
        newTexture.transform.localScale = Vector3.one;

        // Keep logging specific (not agnostic).
        if (newFinding.texturePath != "0") {
            Debug.Log("Added color: Name: " + newFinding.name + " Texture: " + newFinding.texturePath);
        }
        else {
            Debug.Log("Added color: Name: " + newFinding.name + " Color: " + newFinding.colorJson);
        }

        findings.Add(newFinding);
    }

    public void clear() {

    }

}
