using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltExit : MonoBehaviour {
	
	[HideInInspector]
	public bool checkAltExit = false;

	private ExitTriggers exitTriggers;

	// Use this for initialization
	void Awake () {
		exitTriggers = GetComponent<ExitTriggers>();
	}
	
	// Update is called once per frame
	void Update () {
		
		checkAltExitFunc();
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//Checks to see if the player leaves the game using level 1's alternate exit
		if(other.tag == "AltExit") {
			checkAltExit = true;
		}
	}
	
	private void checkAltExitFunc() {
		
		//if the player reaches the alternate exit in the beginning
		if( checkAltExit == true) {
			exitTriggers.winText.text = "Too scary for you?";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		}
		
		//for the player to continue with the game and go to the ending they have to have reached the alt end on the 1st level and press "space"
		if(checkAltExit == true && Input.GetKeyDown(KeyCode.Space)){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			//displays the ending credits and thanks player for playing and yeah other stuff...
			exitTriggers.endingPanel.SetActive(true);
		}
	}

}
