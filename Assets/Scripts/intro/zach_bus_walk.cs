using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zach_bus_walk : MonoBehaviour {

	GameObject target;
	GameObject player;

	Rigidbody2D bus;
	Rigidbody2D rb;

	private Transform t;
	bool zachWalk;

	void Start () {
		// assign objects
		player = GameObject.FindGameObjectWithTag("Player");
		target = GameObject.FindGameObjectWithTag("bus");

		// get RigidBody component to control velocity
		bus = target.gameObject.GetComponent<Rigidbody2D> (); 
		rb = player.gameObject.GetComponent<Rigidbody2D> ();

		// get Transform component of Zach
		t = this.gameObject.GetComponent<Transform> ();

		// flag to check if Zach is walking
		zachWalk = false;
	}

	void Update () {
		// Zach gets off bus if he has not wwalked and bus stops 
		if (!zachWalk && bus.velocity.x == 0) {
			t.transform.position = new Vector3(3.5f, -3, -2);
		}

		// Zach walks home
		if (transform.position.z == -2) {
			zachWalk = true;
			rb.velocity = new Vector2 (2, 0);
		}

		// When Zach reaches end of screen, switch to "walking" scene
		if(transform.position.x > 7) {
			SceneManager.LoadScene ("intro2");
		}
	}
}