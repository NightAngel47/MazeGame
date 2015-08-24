using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour {
	
	[HideInInspector]
	public bool checkLockedDoor = false;

	private ExitTriggers exitTriggers;

	// Use this for initialization
	void Awake () {
		exitTriggers = GetComponent<ExitTriggers>();
	}

	// Update is called once per frame
	void Update () {
		
		checkLockedDoorFunc();
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//Check is the the player collided with the locked door
		if(other.tag == "LockedDoor") {
			checkLockedDoor = true;
		}
	}
	
	private void checkLockedDoorFunc() {
		
		//if the player reaches the alternate exit in the beginning
		if(checkLockedDoor == true && exitTriggers.hasKey == true) {
			exitTriggers.winText.text = "You've unlocked the door with your key.";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		}
		else if(checkLockedDoor == true && exitTriggers.hasKey == false) {
			exitTriggers.winText.text = "Hmm, it's locked. Looks like I'll need a key.";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		}
		
		//for the player to continue with the game and go to the ending they have to have reached the alt end on the 1st level and press "space"
		if(checkLockedDoor == true && Input.GetKeyDown(KeyCode.Space) && exitTriggers.hasKey == true){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			exitTriggers.hasKey = false;
			exitTriggers.nextLevel();
		}
		//for the player to continue with the game and go to the ending they have to have reached the alt end on the 1st level and press "space"
		if(checkLockedDoor == true && Input.GetKeyDown(KeyCode.Space) && exitTriggers.hasKey == false){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			exitTriggers.hasKey = false;
		}
	}
}
