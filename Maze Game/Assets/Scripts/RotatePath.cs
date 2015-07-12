using UnityEngine;
using System.Collections;

public class RotatePath : MonoBehaviour {

	public GameObject rotatingPath;
	public float speed = 0.25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		rotatingPath.transform.Rotate(Vector3.forward * speed);
	}
}
