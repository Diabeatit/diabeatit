using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zach_walking : MonoBehaviour {

	Rigidbody2D rb;

	void Start () {
		// get RigidBody component set velocity
		rb = this.gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (2, 0);
	}

	void Update () {

		// When Zach reaches door, switch to "home" scene
		if(transform.position.x > 1.4) {
			SceneManager.LoadScene ("home");
		}
	}
}