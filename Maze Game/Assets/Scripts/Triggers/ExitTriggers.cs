using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitTriggers : MonoBehaviour {
	
	public Text winText;
	public Text subWinText;
	public GameObject winTextObj;
	public GameObject playerObj;
	public GameObject endingPanel;		//Store a reference to the Game Object 
	public bool hasKey = false;
	public int levelNum = 1;

	private LockedDoor lockedDoor;
	private Win win;

	void Awake() {
		lockedDoor = GetComponent<LockedDoor>();
		win = GetComponent<Win>();
	}

	// Update is called once per frame
	void Update() {

	}

	public void nextLevel() {
		//makes player active false so nothing bad happends while moving player
		playerObj.SetActive(false);
		levelNum++; //increases level number so it correctly moves player to the next level
		win.checkWin = false; //the player hasn't won the next level so winning is false
		lockedDoor.checkLockedDoor = false; //the player hasn't unlocked the next door so the door is locked
		
		if(levelNum == 2) {
			playerObj.transform.Translate(7, 0, Time.deltaTime); //moves player to level 2 start
			playerObj.SetActive(true); //makes player active true so they can begin again
		}

		if(levelNum == 3) {
			playerObj.transform.Translate(7, 0, Time.deltaTime); //moves player to level 3 start
			playerObj.SetActive(true); //makes player active true so they can begin again
		}

		if(levelNum == 4) {
			playerObj.transform.Translate(7, 0, Time.deltaTime); //moves player to level 4 start
			playerObj.SetActive(true); //makes player active true so they can begin again
		}
		
		if(levelNum == 5) {
			playerObj.transform.Translate(24, 6, Time.deltaTime); //moves player to level 5 start
			playerObj.SetActive(true); //makes player active true so they can begin again
		}
	}
}
