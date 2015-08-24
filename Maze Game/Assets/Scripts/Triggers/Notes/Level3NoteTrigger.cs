using UnityEngine;
using System.Collections;

public class Level3NoteTrigger : MonoBehaviour {
	
	[HideInInspector]
	public bool isReadingNote = false;
	public GameObject level3Note;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		doneLevel3Note();
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//if the player finds the note on level 3 then show it
		if(other.tag == "Level3Note") {
			showLevel3Note();
		}
	}

	//show the note for level 3
	private void showLevel3Note() {
		level3Note.SetActive(true);
		isReadingNote = true;
		
	}
	//hide the note for level 3
	private void doneLevel3Note() {
		if(isReadingNote == true && Input.GetKeyDown("space")) {
			level3Note.SetActive(false);
			isReadingNote = false;
		}
	}
}
