using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodGo : MonoBehaviour {

    // create speed for food object

    float speed;
	// Use this for initialization
	void Start () {

        speed = 3f; // set speed

	}

	// Update is called once per frame
	void Update () {

        // get food posisition
        Vector2 pos = transform.position;

        // compute new food posisition
        pos = new Vector2(pos.x - speed * Time.deltaTime,pos.y);


        // update the new food posisition
        transform.position = pos;

        // get the bottom left part of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

        if(pos.x<min.x){
            Destroy(gameObject);
			if(this.gameObject.CompareTag("Food")){
                PlayerController.incCount();
            }
			else if(this.gameObject.CompareTag("Candy")){
                PlayerController.decCount();
            }
        }

	}

	void OnTriggerEnter2D(Collider2D other) {



		// Detect collision with bullet
		if (other.gameObject.CompareTag ("Laser") && this.gameObject.CompareTag ("Candy")) {

			Destroy (other.gameObject);
			Destroy (gameObject);
			PlayerController.incCount ();

		} 
		else if (other.gameObject.CompareTag ("Laser") && this.gameObject.CompareTag ("Food")) {

			Destroy (other.gameObject);
			Destroy (gameObject);
			PlayerController.decCount ();

		} 
	}
}
