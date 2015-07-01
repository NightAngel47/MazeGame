using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed = 4f;
	public GameObject WinTrigger;
	public Text winText;
	public GameObject winTextObj;
	public GameObject playerObj;

	//private int levelNum = 1;
	private bool checkWin = false;
	private Rigidbody2D rb2D;

	// Use this for initialization
	void Awake () {
		rb2D = GetComponent<Rigidbody2D>();
		winTextObj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {


		playerMovement(checkWin);

		if( checkWin == true) {
			winText.text = "Exit Found";
			winTextObj.SetActive(true);
			//loadNewLevel();
		}
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//Check if the tag of the trigger collided with is Exit.
		if(other.tag == "Win") {
			checkWin = true;
		}
	}

	private void playerMovement(bool win) {
		if(win == false) {
			if(Input.GetKey(KeyCode.D)) {
				rb2D.AddForce(Vector2.right * speed);
			}
			if(Input.GetKey(KeyCode.A)) {
				rb2D.AddForce(Vector2.left * speed);
			}
			if(Input.GetKey(KeyCode.W)) {
				rb2D.AddForce(Vector2.up * speed);
			}
			if(Input.GetKey(KeyCode.S)) {
				rb2D.AddForce(Vector2.down * speed);
			}
		}
	}

	/* private void loadNewLevel() {
		levelNum++;

		playerObj.transform.position = 
	}
	*/
}
