using UnityEngine;
using System.Collections;

public class RotatePath : MonoBehaviour {

	public GameObject rotatingPath;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		rotatingPath.transform.Rotate(Vector2.right * 4);
	}
}
