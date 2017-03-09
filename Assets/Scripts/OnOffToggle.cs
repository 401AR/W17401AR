using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnOffToggle : MonoBehaviour {
	public Button Apply;
	// Use this for initialization
	void Start () {
		Button btn = Apply.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
		
	}
	
    public void toggle() {
        Debug.Log("Value Changed");
    }

	// Update is called once per frame
	void Update () {
		
	}

	public void TaskOnClick(){
		Debug.Log ("HI");
	}
}
