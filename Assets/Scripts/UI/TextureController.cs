/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: SkinToneController.cs
 * 
 * Description: Provides handling of dynamic content for SkinToneController.
 * Credits: http://www.folio3.com/blog/creating-dynamic-scrollable-lists-with-new-unity-canvas-ui/
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureController : MonoBehaviour
{
    public DBHandler dbHandler;
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    protected List<SyncListFinding> textures;

    void Start() {
        populate();
    }

    public void populate()
    {

        textures = dbHandler.getTextures();

        // 2. Iterate through the data, 
        //	  instantiate prefab, 
        //	  set the data, 
        //	  add it to panel
        foreach (SyncListFinding texture in textures)
        {
            GameObject newTexture = Instantiate(ListItemPrefab) as GameObject;
            SlotItem controller = newTexture.GetComponent<SlotItem>() as SlotItem;
            controller.Preview.sprite = Resources.Load<Sprite>(texture.texturePath);
            controller.Name.text = texture.name;
            newTexture.transform.SetParent(ContentPanel.transform, false);
            newTexture.transform.localScale = Vector3.one;
            Debug.Log("Added color: Name: " + texture.name + " Texture: " + texture.texturePath);
        }

    }

}
