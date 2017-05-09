using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBus : MonoBehaviour {

	Rigidbody2D rb;

	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (6, 0);
	}

	void Update () {
		if(transform.position.x > 2) {
			rb.velocity = new Vector2 (0, 0);
		}
	}
}