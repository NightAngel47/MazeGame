using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 4f;

	private Rigidbody2D rb2D;

	// Use this for initialization
	void Awake () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.D)) {
			rb2D.AddForce(Vector2.right * speed);
		}
		if(Input.GetKey(KeyCode.A)) {
			rb2D.AddForce(Vector2.left * speed);
		}
		if(Input.GetKey(KeyCode.W)) {
			rb2D.AddForce(Vector2.up * speed);
		}
		if(Input.GetKey(KeyCode.S)) {
			rb2D.AddForce(Vector2.down * speed);
		}
	}
}
