using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodGo : MonoBehaviour {

    
    // create speed for food object
    private float speed;

	private bool mouseEntered;


    // Gives script access to animator component of gameObjects and then 
    // initializes the condition parameter “isClickedOn” to false, added WI2019
    Animator anim;
    // Use this for initialization
	void Start () {
		
        speed = 3f; // set speed
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isClickedOn", false);
	}

	// Update is called once per frame
	void Update () {
		// Check for paused state
		if (!gameDisplay.isPaused ()) {
			// get food posisition
			Vector2 pos = transform.position;

			// compute new food posisition
			pos = new Vector2 (pos.x - speed * Time.deltaTime, pos.y);

			// update the new food posisition
			transform.position = pos;

			// get the bottom left part of the screen
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

			if (pos.x < min.x) {
				Destroy (gameObject);
			}

            // Added WI2019, plays "poof" after items get tapped and before they
            // get destroyed
			if (mouseEntered && Input.GetMouseButtonDown (0)) {
				gameDisplay.updateDisplay (this.gameObject.tag);
				print (this.gameObject.tag);

                anim.SetBool("isClickedOn", true);
                Debug.Log("ISCLICKED is now:" + anim.GetBool("isClickedOn"));
                
                Invoke("deactivate", 1);
                Destroy (this.gameObject,1);
				foodSpawn.foodConsumed++;
			}
		} 
	}

	void OnMouseEnter(){
		mouseEntered = true;
	}

	void OnMouseExit(){
		mouseEntered = false;
	}

    // Function to be used by Invoke with delay, added WI2019 for "poof"
    void deactivate()
    {
        this.gameObject.SetActive(false);
    }

}

    