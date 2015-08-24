using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FalseExit : MonoBehaviour {
	
	[HideInInspector]
	public bool checkFalseExit = false;

	private ExitTriggers exitTriggers;

	// Use this for initialization
	void Awake () {
		exitTriggers = GetComponent<ExitTriggers>();
	}
	
	// Update is called once per frame
	void Update () {
		
		checkFalseExitFunc();
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//Check if the player collided with the false exit
		if(other.tag == "FalseExit") {
			checkFalseExit = true;
		}
	}
	
	private void checkFalseExitFunc() {
		
		//if the player reaches the alternate exit in the beginning
		if(checkFalseExit == true) {
			exitTriggers.winText.text = "Sweet the exit! Oh wait..." + "\n" + "it's just a flase door... fucking assholes.";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		}
		
		//for the player to continue with the game and go to the ending they have to have reached the alt end on the 1st level and press "space"
		if(checkFalseExit == true && Input.GetKeyDown(KeyCode.Space)){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			checkFalseExit = false;
			
		}
	}

}
