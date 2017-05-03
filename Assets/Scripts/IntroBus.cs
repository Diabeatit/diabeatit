using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroBus : MonoBehaviour {

	Rigidbody2D rb;

	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (10, 0);
	}

	void Update () {
		if(transform.position.x>5)
			SceneManager.LoadScene ("main");
	}
}