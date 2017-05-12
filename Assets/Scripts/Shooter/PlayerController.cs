using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject laser; // this is the players laser prefab
	public GameObject laserPosition;
	public float speed;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

	}

	// Update is called just before applying any physics calculations

	void Update(){
		// fire bullet when space bar is pressed
		if (Input.GetKeyDown ("space")) {

			//instantiate the laser
			GameObject laser1 = (GameObject)Instantiate (laser);

			// set the lasers initial position
			laser1.transform.position = laserPosition.transform.position;
			
		}
	}
	void FixedUpdate () {

		// fire bullets when the spacebar is pressed
        // Grabs input from the player through the keyboard
        // and stores in a float
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        rb2d.AddForce(movement*speed);

	}
}
