using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed = 8f;

	private bool isreading = false;
	private Rigidbody2D rb2D;
	private StartingText startText;
	private ExitTriggers exitTriggers;
	private Level1NoteTrigger L1NT;
	private Level3NoteTrigger L3NT;
	
	// Use this for initialization
	void Awake() {
		rb2D = GetComponent<Rigidbody2D>();
		startText = GetComponent<StartingText>();
		exitTriggers = GetComponent<ExitTriggers>();
		L1NT = GetComponent<Level1NoteTrigger>();
		L3NT = GetComponent<Level3NoteTrigger>();
	}

	// Update is called once per frame
	void Update() {
		reading(L1NT.isReadingNote, L3NT.isReadingNote);
	}

	void FixedUpdate() {
		//moves player while game is active and player is not doing something else
		playerMovement(exitTriggers.checkWin, exitTriggers.checkAltExit, startText.checkStart, isreading, exitTriggers.checkVoidDeath);
	}

	//moves player if they aren't doing something else
	private void playerMovement(bool win, bool altExit, bool start, bool readingNote, bool voidDeath) {
		//while the exit hasn't been found the player can move, but when the exit is found then the player movement stops
		if(win == false && altExit == false && start == false && readingNote == false && voidDeath == false) {
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

	private void reading(bool l1NT, bool l3NT) {

		if(l1NT == true || l3NT == true) {
			isreading = true;
		}

		if(l1NT == false || l3NT == false) {
			isreading = false;
		}
	}
}