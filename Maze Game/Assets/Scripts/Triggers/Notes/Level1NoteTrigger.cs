using UnityEngine;
using System.Collections;

public class Level1NoteTrigger : MonoBehaviour {
	
	[HideInInspector]
	public bool isReadingNote = false;
	public GameObject level1Note;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		doneLevel1Note();
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//if the player finds the note on level 1 then show it
		if(other.tag == "Level1Note") {
			showLevel1Note();
		}
	}

	//show the note for level 1
	private void showLevel1Note() {
		level1Note.SetActive(true);
		isReadingNote = true;
		
	}
	//hide the note for level 1
	private void doneLevel1Note() {
		if(isReadingNote == true && Input.GetKeyDown("space")) {
			level1Note.SetActive(false);
			isReadingNote = false;
		}
	}
}
