using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartingText : MonoBehaviour {
	
	public GameObject startTextObj;
	[HideInInspector]
	public bool checkStart = false;

	// Use this for initialization
	void Awake () {
		checkStart = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		//displays starting text
		if(checkStart == true) {
			startTextObj.SetActive(true);
		}
		//hides starting text once player is ready to start
		if(checkStart == true && Input.GetKeyDown(KeyCode.Space)){
			startTextObj.SetActive(false);
			checkStart = false;
		}
	}
}
