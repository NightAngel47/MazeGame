using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoidDeath : MonoBehaviour {
	
	[HideInInspector]
	public bool checkVoidDeath = false;

	private ExitTriggers exitTriggers;

	// Use this for initialization
	void Awake () {
		exitTriggers = GetComponent<ExitTriggers>();
	}
	
	// Update is called once per frame
	void Update () {
		
		checkVoidDeathFunc();
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//Check if the tag of the trigger collided with is the void by the wooden walkways.
		if(other.tag == "Void") {
			checkVoidDeath = true;
		}
	}
	
	private void checkVoidDeathFunc() {
		
		//if the player falls into the void show them this message
		if( checkVoidDeath == true) {
			exitTriggers.winText.text = "You fell to you're death.";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		}
		
		//for the player to continue with the game and go to the ending they have to fall and die and press "space"
		if(checkVoidDeath == true && Input.GetKeyDown(KeyCode.Space)){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			//displays the ending credits and thanks player for playing and yeah other stuff...
			exitTriggers.endingPanel.SetActive(true);
		}
	}
}
