using UnityEngine;
using System.Collections;

public class Level5Note : MonoBehaviour {
	
	[HideInInspector]
	public bool isReadingNote = false;
	public GameObject level5Note;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		doneLevel5Note();
	}
	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//if the player finds the note on level 5 then show it
		if(other.tag == "Level5Note") {
			showLevel5Note();
		}
	}
	
	//show the note for level 5
	private void showLevel5Note() {
		level5Note.SetActive(true);
		isReadingNote = true;
		
	}
	//hide the note for level 5
	private void doneLevel5Note() {
		if(isReadingNote == true && Input.GetKeyDown("space")) {
			level5Note.SetActive(false);
			isReadingNote = false;
		}
	}
}
