using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingScene : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;

	private Transform t;
	bool zachWalk;

	void Start () {
		// assign player object
		player = GameObject.FindGameObjectWithTag("Player");
		// rigidBody component to control velocity of player object
		rb = player.gameObject.GetComponent<Rigidbody2D> ();
		// transform component to get position of player object
		t = this.gameObject.GetComponent<Transform> ();
		// flag to start dialogue
		zachWalk = false;
			
	}
	
	void Update () {
		if (transform.position.z == -2) {
			zachWalk = true;
			rb.velocity = new Vector2 (2, 0);
		}
	}
}
