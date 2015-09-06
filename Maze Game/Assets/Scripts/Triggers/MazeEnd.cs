using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MazeEnd : MonoBehaviour {
	
	[HideInInspector]
	public bool checkMazeEnd = false;

	private ExitTriggers exitTriggers;

	// Use this for initialization
	void Awake () {
		exitTriggers = GetComponent<ExitTriggers>();
	}
	
	// Update is called once per frame
	void Update () {
		
		checkMazeEndFunc();
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//Check if the tag of the trigger collided with is the End of the game.
		if(other.tag == "MazeEnd") {
			checkMazeEnd = true;
		}
	}
	
	private void checkMazeEndFunc() {
		
		//if the player reaches the end of the last level then they've beat the game and this displays to tell them so
		if(checkMazeEnd == true && exitTriggers.hasKey == true) {
			exitTriggers.winText.text = "Exit Found";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		} else if(checkMazeEnd == true && exitTriggers.hasKey == false) {
			exitTriggers.winText.text = "Hmm, it's locked." + "\n" + "Looks like I'll need a key.";
			exitTriggers.subWinText.text = "(press space to continue)";
			exitTriggers.winTextObj.SetActive(true);
		}
		
		//for the player to continue with the game and go to the ending they have to have reached the end of the last level and press "space"
		if(checkMazeEnd == true && Input.GetKeyDown(KeyCode.Space) && exitTriggers.hasKey == true){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			exitTriggers.hasKey = false;
			//displays the ending credits and thanks player for playing and yeah other stuff...
			exitTriggers.endingPanel.SetActive(true);
			exitTriggers.level5.SetActive(false);

		}
		//for the player to continue with the game they have to find the key
		if(checkMazeEnd == true && Input.GetKeyDown(KeyCode.Space) && exitTriggers.hasKey == false){
			//turns off win text
			exitTriggers.winTextObj.SetActive(false);
			exitTriggers.hasKey = false;
		}
	}
}
