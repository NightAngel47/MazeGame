using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryNotes : MonoBehaviour {

	[HideInInspector]
	public bool isReadingNote = false;
	public GameObject level1Note;
	public Image level1NoteImg;
	public Text level1NoteText;
	public GameObject level3Note;
	public Image level3NoteImg;
	public Text level3NoteText;

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
		//if the player finds the note on level 3 then show it
		if(other.tag == "Level3Note") {
			showLevel3Note();
		}
	}

	private void showLevel1Note() {
		level1Note.SetActive(true);
		isReadingNote = true;

	}

	private void doneLevel1Note() {
		if(isReadingNote == true && Input.GetKeyDown("space")) {
			level1Note.SetActive(false);
			isReadingNote = false;
		}
	}

	private void showLevel3Note() {

	}
}
