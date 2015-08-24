using UnityEngine;
using System.Collections;

public class Level4Note : MonoBehaviour {
	
	[HideInInspector]
	public bool isReadingNote = false;
	public GameObject level4Note;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		doneLevel4Note();
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//if the player finds the note on level 4 then show it
		if(other.tag == "Level4Note") {
			showLevel4Note();
		}
	}
	
	//show the note for level 4
	private void showLevel4Note() {
		level4Note.SetActive(true);
		isReadingNote = true;
		
	}
	//hide the note for level 4
	private void doneLevel4Note() {
		if(isReadingNote == true && Input.GetKeyDown("space")) {
			level4Note.SetActive(false);
			isReadingNote = false;
		}
	}
}
