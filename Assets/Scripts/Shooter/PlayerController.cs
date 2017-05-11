using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

	}

	// Update is called just before applying any physics calculations
	void FixedUpdate () {
        // Grabs input from the player through the keyboard
        // and stores in a float
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        rb2d.AddForce(movement*speed);

	}
}
