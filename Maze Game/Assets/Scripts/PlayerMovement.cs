using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed = 8f;

	private Rigidbody2D rb2D;
	private StartingText startText;
	private ExitTriggers exitTriggers;
	private StoryNotes storyNotes;
	
	// Use this for initialization
	void Awake() {
		rb2D = GetComponent<Rigidbody2D>();
		startText = GetComponent<StartingText>();
		exitTriggers = GetComponent<ExitTriggers>();
		storyNotes = GetComponent<StoryNotes>();
	}

	// Update is called once per frame
	void Update() {
		
	}

	void FixedUpdate() {
		//moves player while game is active and player is not doing something else
		playerMovement(exitTriggers.checkWin, exitTriggers.checkAltExit, startText.checkStart, storyNotes.isReadingNote);
	}

	//moves player if they aren't doing something else
	private void playerMovement(bool win, bool altExit, bool start, bool readingNote) {
		//while the exit hasn't been found the player can move, but when the exit is found then the player movement stops
		if(win == false && altExit == false && start == false && readingNote == false) {
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
				rb2D.AddForce(Vector2.right * speed);
			}
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
				rb2D.AddForce(Vector2.left * speed);
			}
			if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
				rb2D.AddForce(Vector2.up * speed);
			}
			if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
				rb2D.AddForce(Vector2.down * speed);
			}
		}
	}
}