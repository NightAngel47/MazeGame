using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//player speed
	public float speed = 8f;
	//reading
	private bool isreading = false;
	//rigidbody
	private Rigidbody2D rb2D;
	//note and text classes
	private StartingText startText;
	private Level1NoteTrigger L1NT;
	private Level3NoteTrigger L3NT;
	private Level4Note L4NT;
	private Level5Note L5NT;
	//trigger classes
	private AltExit altExit;
	private FalseExit falseExit;
	private VoidDeath voidDeath;
	private Win win;
	
	// Use this for initialization
	void Awake() {
		//rigidbody
		rb2D = GetComponent<Rigidbody2D>();
		//note and text classes
		startText = GetComponent<StartingText>();
		L1NT = GetComponent<Level1NoteTrigger>();
		L3NT = GetComponent<Level3NoteTrigger>();
		L4NT = GetComponent<Level4Note>();
		L5NT = GetComponent<Level5Note>();
		//trigger classes
		altExit = GetComponent<AltExit>();
		falseExit = GetComponent<FalseExit>();
		voidDeath = GetComponent<VoidDeath>();
		win = GetComponent<Win>();

	}

	// Update is called once per frame
	void Update() {
		//check for reading
		reading(L1NT.isReadingNote, L3NT.isReadingNote, L4NT.isReadingNote, L5NT.isReadingNote);
	}

	void FixedUpdate() {
		//moves player while game is active and player is not doing something else
		playerMovement(win.checkWin, altExit.checkAltExit, startText.checkStart, isreading, voidDeath.checkVoidDeath, falseExit.checkFalseExit);
	}

	//moves player if they aren't doing something else
	private void playerMovement(bool win, bool altExit, bool start, bool readingNote, bool voidDeath, bool falseExit) {
		//while the exit hasn't been found the player can move, but when the exit is found then the player movement stops
		if(win == false && altExit == false && start == false && readingNote == false && voidDeath == false && falseExit == false) {
			//right player movement
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
				rb2D.AddForce(Vector2.right * speed);
			}
			//left player movement
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
				rb2D.AddForce(Vector2.left * speed);
			}
			//up player movement
			if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
				rb2D.AddForce(Vector2.up * speed);
			}
			//down player movement
			if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
				rb2D.AddForce(Vector2.down * speed);
			}
		}
	}
	//check for reading function
	private void reading(bool l1NT, bool l3NT, bool l4NT, bool l5NT) {
		//checks if reading note is going
		if(l1NT == true || l3NT == true || l4NT == true || l5NT == true) {
			isreading = true;
		}
		//checks if reading note is done
		if(l1NT == false || l3NT == false || l4NT == false || l5NT == false) {
			isreading = false;
		}
	}
}