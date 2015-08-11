using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitTriggers : MonoBehaviour {

	public GameObject WinTrigger;
	public Text winText;
	public Text subWinText;
	public GameObject winTextObj;
	public GameObject playerObj;
	public GameObject endingPanel;		//Store a reference to the Game Object EndingPanel
	[HideInInspector]
	public bool checkWin = false;
	[HideInInspector]
	public bool checkAltExit = false;
	[HideInInspector]
	public bool checkMazeEnd = false;
	
	private int levelNum = 1;
	
	// Update is called once per frame
	void Update () {

		checkWinFunc();
		checkMazeEndFunc();
		checkAltExiteFunc();
	}
	
	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other) {
		//Check if the tag of the trigger collided with is the Door.
		if(other.tag == "Win") {
			checkWin = true;
		}
		//Checks to see if the player leaves the game using level 1's alternate exit
		if(other.tag == "AltExit") {
			checkAltExit = true;
		}
		//Check if the tag of the trigger collided with is the End of the game.
		if(other.tag == "MazeEnd") {
			checkMazeEnd = true;
		}
	}

	private void checkWinFunc(){
		
		//if the player reaches the end of the current level then they've beat it and this displays to tell them so
		if( checkWin == true) {
			winText.text = "Door Found";
			subWinText.text = "(press space to continue)";
			winTextObj.SetActive(true);
		}
		//for the player to continue with the game and go to the next level they have to have reached the end of the current one and press "space"
		if(checkWin == true && Input.GetKeyDown(KeyCode.Space)){
			//turns off win text
			winTextObj.SetActive(false);
			//moves player to next level
			nextLevel();
		}
	}

	private void checkMazeEndFunc() {
		
		//if the player reaches the end of the last level then they've beat the game and this displays to tell them so
		if( checkMazeEnd == true) {
			winText.text = "Exit Found";
			subWinText.text = "(press space to continue)";
			winTextObj.SetActive(true);
		}
		
		//for the player to continue with the game and go to the ending they have to have reached the end of the last level and press "space"
		if(checkMazeEnd == true && Input.GetKeyDown(KeyCode.Space)){
			//turns off win text
			winTextObj.SetActive(false);
			//displays the ending credits and thanks player for playing and yeah other stuff...
			endingPanel.SetActive(true);
		}
	}

	private void checkAltExiteFunc() {
		
		//if the player reaches the alternate exit in the beginning
		if( checkAltExit == true) {
			winText.text = "Too scary for you?";
			subWinText.text = "(press space to continue)";
			winTextObj.SetActive(true);
		}
		
		//for the player to continue with the game and go to the ending they have to have reached the alt end on the 1st level and press "space"
		if(checkAltExit == true && Input.GetKeyDown(KeyCode.Space)){
			//turns off win text
			winTextObj.SetActive(false);
			//displays the ending credits and thanks player for playing and yeah other stuff...
			endingPanel.SetActive(true);
		}
	}
	
	private void nextLevel() {
		//makes player active false so nothing bad happends while moving player
		playerObj.SetActive(false);
		levelNum++; //increases level number so it correctly moves player to the next level
		checkWin = false; //the player hasn't won the next level so winning is false
		
		if(levelNum == 2) {
			playerObj.transform.Translate(7, 0, Time.deltaTime); //moves player to level 2 start
			playerObj.SetActive(true); //makes player active true so they can begin again
		}

		if(levelNum == 3) {
			playerObj.transform.Translate(7, 0, Time.deltaTime); //moves player to level 3 start
			playerObj.SetActive(true); //makes player active true so they can begin again
		}
	}
}
