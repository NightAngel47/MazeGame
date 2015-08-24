using UnityEngine;
using System.Collections;

public class Level2NoteTrigger : MonoBehaviour {
	
	[HideInInspector]
	public bool isReadingNote = false;
	public GameObject level2Note;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		doneLevel2Note();
	}
	
	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//if the player finds the note on level 2 then show it
		if(other.tag == "Level2Note") {
			showLevel2Note();
		}
	}
	
	//show the note for level 2
	private void showLevel2Note() {
		level2Note.SetActive(true);
		isReadingNote = true;
		
	}
	//hide the note for level 2
	private void doneLevel2Note() {
		if(isReadingNote == true && Input.GetKeyDown("space")) {
			level2Note.SetActive(false);
			isReadingNote = false;
		}
	}
}
