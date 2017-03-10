using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyButton : MonoBehaviour {
    public Baby baby;
    public Button Apply;

    // Use this for initialization
    void Start () {
        Button btn = Apply.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TaskOnClick() {
        Debug.Log("HI");

        SyncListFinding test = new SyncListFinding();
        test.position.Set(1.0f, 0.0f, 0.0f);

        Debug.Log(baby);
        baby.addFinding(test);

        Debug.Log(JsonUtility.ToJson(test));

        Debug.Log(baby.findings.Count);
    }

}
