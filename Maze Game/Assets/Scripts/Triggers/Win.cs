using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Win : MonoBehaviour {

	[HideInInspector]
	public bool checkWin = false;

	private ExitTriggers exitTriggers;

	// Use this for initialization
	void Awake () {
		exitTriggers = GetComponent<ExitTriggers>();
	}
	
	// Update is called once per frame
	void Update () {
		
		checkWinFunc();
	}
	
	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//Check if the tag of the trigger collided with is the Door.
		if(other.tag == "Win") {
			checkWin = true;
		}
	}

	private void checkWinFunc(){
		
		//if the player reaches the end of the current level then they've beat it and this displays to tell them so
		if( checkWin == true) {
			exitTriggers.winText.text = "Door Found";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		}
		//for the player to continue with the game and go to the next level they have to have reached the end of the current one and press "space"
		if(checkWin == true && Input.GetKeyDown(KeyCode.Space)){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			//moves player to next level
			exitTriggers.loadNextLevel();
		}
	}

}
