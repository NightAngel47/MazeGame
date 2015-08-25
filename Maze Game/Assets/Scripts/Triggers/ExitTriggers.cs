using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitTriggers : MonoBehaviour {
	
	public Text winText;
	public Text subWinText;
	public GameObject winTextObj;
	public GameObject endingPanel;		//Store a reference to the Game Object 
	public bool hasKey = false;
	
	public GameObject playerObj;
	public int levelNum = 1;
	
	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;
	public GameObject level5;
	
	private ExitTriggers exitTriggers;
	private Win win;
	private LockedDoor lockedDoor;

	void Awake() {
		lockedDoor = GetComponent<LockedDoor>();
		win = GetComponent<Win>();
		
		level2.SetActive(false);
		level3.SetActive(false);
		level4.SetActive(false);
		level5.SetActive(false);
	}

	// Update is called once per frame
	void Update() {

	}

	public void loadNextLevel() {
		//makes player active false so nothing bad happends while moving player
		playerObj.SetActive(false);
		levelNum++; //increases level number so it correctly moves player to the next level
		win.checkWin = false; //the player hasn't won the next level so winning is false
		lockedDoor.checkLockedDoor = false; //the player hasn't unlocked the next door so the door is locked

		if(levelNum == 2) {
			level2.SetActive(true);
			playerObj.transform.Translate(7, 0, Time.deltaTime); //moves player to level 2 start
			playerObj.SetActive(true); //makes player active true so they can begin again
			level1.SetActive(false);
		}

		if(levelNum == 3) {
			level3.SetActive(true);
			playerObj.transform.Translate(7, 0, Time.deltaTime); //moves player to level 3 start
			playerObj.SetActive(true); //makes player active true so they can begin again
			level2.SetActive(false);
		}

		if(levelNum == 4) {
			level4.SetActive(true);
			playerObj.transform.Translate(7, 0, Time.deltaTime); //moves player to level 4 start
			playerObj.SetActive(true); //makes player active true so they can begin again
			level3.SetActive(false);
		}

		if(levelNum == 5) {
			level5.SetActive(true);
			playerObj.transform.Translate(24, 6, Time.deltaTime); //moves player to level 5 start
			playerObj.SetActive(true); //makes player active true so they can begin again
			level4.SetActive(false);
		}
	}
}
