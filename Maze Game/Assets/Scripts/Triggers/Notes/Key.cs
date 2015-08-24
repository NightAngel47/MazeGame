using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	private bool checkKey = false;
	private ExitTriggers exitTriggers;

	// Use this for initialization
	void Awake () {
		exitTriggers = GetComponent<ExitTriggers>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//if the player finds the key they then have it
		if(other.tag == "Key") {
			exitTriggers.hasKey = true;
			checkKey = true;
			other.gameObject.SetActive(false);
		}
	}

	private void hasKeyMessage() {
		
		//if the player reaches the alternate exit in the beginning
		if(checkKey == true) {
			exitTriggers.winText.text = "I found a key.";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		}
		
		//for the player to continue with the game and go to the ending they have to have reached the alt end on the 1st level and press "space"
		if(checkKey == true && Input.GetKeyDown(KeyCode.Space)){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			checkKey = false;
			
		}
	}
}